using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Schoolmngt.Commen
{
    public class ImageConverter
    {
        public string SaveByteArrayAsImage(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            String name = "non";
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                name = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString();

                image = Image.FromStream(ms);
                  image.Save("D:\\backup\\03.21\\cyclonefinal\\School\\Schoolmngt\\Commen\\" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //image.Save("~Commen\\" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //image.Save("C:\\Users\\Sandun\\Desktop\\New folder (3)\\New folder\\School\\Schoolmngt\\Commen\\" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //D:\backup\03.21\cyclonefinal\School\Schoolmngt\Commen\
            }
            return name;
        }
    }
}