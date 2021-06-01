# Camera-calibration-opencvSharp4
This is a sample code to calibrate camera using opencvsharp4.

I used the NuGet package "OpenCvSharp4.Windows" verson: 4.5.2.20210404  (https://www.nuget.org/packages/OpenCvSharp4.Windows/4.5.2.20210404?_src=template)
in Visual Studio 2019

target Framework: .Net 5.0

# Project summary
generating camera matrix and distortion coefficient for undistorting some images.

(some images contains checker board pattern from an camera)  
->(calibrate : generating mtxNdist.txt)  
-> (you can undistort all images from the same camea) 

# p.s
I had been in a big trouble while developing a project that calibrates camera,  
because the information of calibration in C# was very rare.  
I refered to many QnA communities.  
Now, I hope everyone not to suffer from this...  
If you have any question, then call me *@jspark-noticekorea* or *@moran991231*
