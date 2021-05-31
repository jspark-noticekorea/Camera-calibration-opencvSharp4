using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Camera_calibration_opencvSharp4
{
    enum CMode
    {
        DISCONNECTED = -1,
        READY = 0,
        SAVE = 1,
        CALI = 2,
    }
    public partial class CamCal : Form
    {

        // checker pattern
        int NX = 5, NY = 4;
        Size pat_size = new Size(5, 4);

        // input image size
        static int W = 600, H = 600;
        Size img_size = new Size(W, H);

        // camera parameters
        double[,] mtx = new double[3, 3], new_mtx = new double[3, 3];
        double[] dist = new double[5];
        private Mat m_mtx, m_dist = new Mat(1, 5, MatType.CV_64FC1), m_new_mtx = Mat.Eye(3, 3, MatType.CV_64FC1);
        private Rect roi = new Rect(), roi550 = new Rect(25, 25, 550, 550);
        private Mat mapx = new Mat(), mapy = new Mat();

        // 
        private CMode mode = CMode.DISCONNECTED;
        private bool isCalibrated = false;

        private bool isConnected = false;
        private string img_path = "", mtx_path = "";
        private string mtx_fname = "mtxNdist.txt";
        int cnt = 0; // the number of save images

        Thread calibThread;
        Thread playThread;
        VideoCapture vc=null;

        Mat imgRead=new Mat();

        public void doPlay()
        {
            Mat img;
            while (true)
            {
                vc.Read(imgRead);
                img = imgRead;
                if (mode == CMode.READY || mode == CMode.SAVE)
                {
                    Point2f[] corners;
                    if (isCalibrated)
                    {
                        Mat temp;
                        ApplyCalibration(img, out temp);
                        pb_right.Image = BitmapConverter.ToBitmap(temp);
                    }
                    else if (Cv2.FindChessboardCorners(img, pat_size, out corners))
                    {
                        if (mode == CMode.SAVE)
                            saveImage(img);
                        Cv2.DrawChessboardCorners(img, pat_size, corners, true);
                    }
                    pb_left.Image = imgRead.ToBitmap();
                }
                Task.Delay(66).Wait();
            }

        }
        public CamCal()
        {
            InitializeComponent();
            lbl_status.ForeColor = System.Drawing.Color.Red;
            lbl_status.Text = "Ready";
        }

        public delegate void DelSetStatus(string s);
        public void saveImage(Mat img)
        {
            Cv2.ImWrite(Path.Combine(img_path, string.Format("img_{0:D4}.bmp", ++cnt)), img);
            Invoke(new DelSetStatus(setStatus), new object[] {
            string.Format("{0} images are saved",cnt) });

        }
        public void setStatus(string s)
        {
            lbl_status.Text = s;
        }
        public void CalcMatrix() // thread function
        {
            mode = CMode.CALI; // busy!
            TermCriteria criteria = new TermCriteria(CriteriaTypes.MaxIter | CriteriaTypes.Eps, 30, 0.001);

            List<Point3f[]> object_points = new List<Point3f[]>();
            List<Point2f[]> image_points = new List<Point2f[]>();

            Point3f[] objp = new Point3f[NX * NY];
            for (int i = 0; i < NX * NY; i++)
                objp[i] = new Point3f((float)(i % NX), (float)(i / NX), 0.0f);


            string[] files = { };
            try
            {
                files = Directory.GetFiles(img_path, "*");
            }
            catch
            {
                this.Invoke(new DelSetStatus(setStatus), new object[] { "Fail to read images" });
                mode = CMode.READY;
                isCalibrated = false;
                return;
            }
            int total = files.Length;
            int progress = 0;
            foreach (string filename in files)
            {
                progress++;
                Mat img = Cv2.ImRead(filename);
                Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
                Point2f[] corners;
                bool ret = Cv2.FindChessboardCorners(img, pat_size, out corners);
                if (ret)
                {
                    object_points.Add(objp);
                    Point2f[] corners2 = Cv2.CornerSubPix(img, corners, new Size(11, 11), new Size(-1, -1), criteria);
                    image_points.Add(corners2);
                }

                this.Invoke(new DelSetStatus(setStatus), new object[] {
            string.Format("processing {0}% : pattern was found in {1}images", (int)(progress * 100.0/ total ), object_points.Count) });

            }
            this.Invoke(new DelSetStatus(setStatus), new object[] { "Please wait for calculating matrix. It may take more than 10 minutes." });

            try
            {
                double retval = Cv2.CalibrateCamera(object_points, image_points, img_size, mtx, dist, out _, out _);
                new_mtx = Cv2.GetOptimalNewCameraMatrix(mtx, dist, img_size, 1.0, img_size, out roi);
            }
            catch
            {
                lbl_status.Text = "Failed to calculate matrix. Save more images and retry";
                isCalibrated = false;
                mode = CMode.READY;
                return;
            }

            this.Invoke(new DelSetStatus(setStatus), new object[] { "Generating matrix is finished. Now, please wait for writing data on file." });

            // write data on file
            StreamWriter sw = new StreamWriter(Path.Combine(mtx_path, mtx_fname));
            for (int i = 0; i < 3; i++) // mtx
            {
                for (int j = 0; j < 3; j++)
                    sw.Write(mtx[i, j] + " ");
                sw.WriteLine();
            }
            foreach (double val in dist) // dist
                sw.Write(val + " ");
            sw.WriteLine();

            for (int i = 0; i < 3; i++) // new mtx
            {
                for (int j = 0; j < 3; j++)
                    sw.Write(new_mtx[i, j] + " ");
                sw.WriteLine();
            }

            sw.Write("{0} {1} {2} {3}", roi.X, roi.Y, roi.Width, roi.Height); // roi
            sw.WriteLine();
            sw.Close();

            // calculating mapping matrix mapx, mapy
            this.Invoke(new DelSetStatus(setStatus), new object[] { "Please wait for making map-matrix" });
            DoubleArr2Mat();
            Cv2.InitUndistortRectifyMap(m_mtx, m_dist, new Mat(), m_new_mtx, img_size, MatType.CV_32FC1, mapx, mapy);

            isCalibrated = true;
            mode = CMode.READY;

            this.Invoke(new DelSetStatus(setStatus), new object[] { "Calibration is finished!!" });
            return;
        }


        public void ApplyCalibration(Mat src, out Mat dst)
        {
            Mat temp = new Mat(src.Size(), MatType.CV_8UC3);
            //Cv2.Undistort(src, temp, InputArray.Create(mtx), InputArray.Create(dist)); // = InitUndistortRectifyMap + remap
            Cv2.Remap(src, temp, mapx, mapy, InterpolationFlags.Linear, BorderTypes.Constant, new Scalar(0, 0, 255)); //  insted of undistort
            temp.Rectangle(roi, Scalar.Blue, 3); // maximum area without distortion
            dst = temp;

        }

        public void DoubleArr2Mat()
        {
            m_mtx = new Mat(3, 3, MatType.CV_64FC1, mtx);
            m_dist = new Mat(1, 5, MatType.CV_64FC1, dist);
            m_new_mtx = new Mat(3, 3, MatType.CV_64FC1, new_mtx);
        }

        private void b_calib_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(img_path))
            {
                lbl_status.Text = "Image path is not valid";
                return;
            }
            if (!Directory.Exists(mtx_path))
            {
                lbl_status.Text = "Mtx path is not valid";
                return;
            }
            calibThread = new Thread(new ThreadStart(CalcMatrix));
            calibThread.IsBackground = true;
            calibThread.Start();


        }

        private void b_read_Click(object sender, EventArgs e)
        {
            if (mode == CMode.CALI)
            {
                lbl_status.Text = "Fail to read mtxNdist.txt. Program is too busy";
                return;
            }
            if (!File.Exists(Path.Combine(mtx_path, mtx_fname)))
            {
                lbl_status.Text = "The \'mtxNdist.txt\'file is not exist in the path";
                return;
            }
            mode = CMode.CALI;
            StreamReader sr = new StreamReader(Path.Combine(mtx_path, mtx_fname));
            lbl_status.Text = "Reading mtxNdist.txt...";
            string[] tokens;
            for (int i = 0; i < 3; i++)
            {
                tokens = sr.ReadLine().Split(' ');
                for (int j = 0; j < 3; j++)
                    mtx[i, j] = double.Parse(tokens[j]);
            }
            tokens = sr.ReadLine().Split(' ');
            for (int i = 0; i < 5; i++)
                dist[i] = double.Parse(tokens[i]);
            for (int i = 0; i < 3; i++)
            {
                tokens = sr.ReadLine().Split(' ');
                for (int j = 0; j < 3; j++)
                    new_mtx[i, j] = double.Parse(tokens[j]);
            }
            tokens = sr.ReadLine().Split(' ');
            roi = new Rect(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]));
            sr.Close();
            DoubleArr2Mat();
            Cv2.InitUndistortRectifyMap(m_mtx, m_dist, new Mat(), m_new_mtx, img_size, MatType.CV_32FC1, mapx, mapy);
            lbl_status.Text = "Finished reading mtxNdist.txt";
            isCalibrated = true;
            mode = CMode.READY;


        }

        private void b_save_image_Click(object sender, EventArgs e)
        {
            if (mode == CMode.DISCONNECTED)
            {
                lbl_status.Text = "Please connect the device first";
                return;
            }
            if (!Directory.Exists(img_path))
            {
                lbl_status.Text = "Image path is not valid";
                return;
            }
            if (mode == CMode.READY)
            {
                mode = CMode.SAVE;
                b_save_image.Text = "stop saving images";
                gb_display.Enabled = false;

            }
            else if (mode == CMode.SAVE)
            {
                mode = CMode.READY;
                b_save_image.Text = "start to save images";
                gb_display.Enabled = true;

            }
        }


        private void b_connect_Click(object sender, EventArgs e)
        {
            vc = new VideoCapture(0, VideoCaptureAPIs.DSHOW);
            playThread = new Thread(doPlay);
            playThread.IsBackground = true;
            playThread.Start();
            mode = CMode.READY;
            b_connect.Enabled = false;
            isConnected = true;
            lbl_status.Text = "Device is connected";
        }


        private void b_mtx_path_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = Application.StartupPath;
            fbd.ShowDialog();
            tb_mtx_path.Text = fbd.SelectedPath;
        }

        private void tb_img_path_TextChanged(object sender, EventArgs e)
        {
            img_path = tb_img_path.Text;
        }

        private void nud_nx_ValueChanged(object sender, EventArgs e)
        {
            NX = (int)nud_nx.Value;
            pat_size.Width = NX;
        }

        private void nud_ny_ValueChanged(object sender, EventArgs e)
        {
            NY = (int)nud_ny.Value;
            pat_size.Height = NY;
        }

        private void tb_mtx_path_TextChanged(object sender, EventArgs e)
        {
            mtx_path = tb_mtx_path.Text;
        }

        private void b_img_path_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = Application.StartupPath;
            fbd.ShowDialog();
            tb_img_path.Text = fbd.SelectedPath;
        }

    }
}
