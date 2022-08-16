
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.DrawingCore;
//using System.DrawingCore.Drawing2D;
//using System.IO;
//using System.Linq;
//using System.Web;

//namespace MediHubSC.Web.Helper
//{
//    public class QrCode
//    {
//        //private static string path = @"~/wwwroot/images/QrCodeImage/";
//        private static int widthQr = 117;
//        private static Random random = new Random();
//        public static string creatingQR(string phone, string idHoinghi)
//        {

//            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
//            //QRCodeData qrCodeData = qrGenerator.CreateQrCode($"{phone}", QRCodeGenerator.ECCLevel.Q);
//            //QRCode qrCode = new QRCode(qrCodeData);
//         //   Bitmap qrCodeImage = qrCode.GetGraphic(20);
//            var datetime = DateTime.Now.ToString("yyyyMMdd");
//            var filename = Guid.NewGuid();
//            string folder = $"QrCodeImage/{idHoinghi}/{datetime}";
//            // full path to file in temp location
//            var filePath = Path.Combine(
//                Directory.GetCurrentDirectory(), "wwwroot",
//                folder);

//            bool folderExists = Directory.Exists(filePath);
//            if (!folderExists)
//                Directory.CreateDirectory(filePath);
//            var path = $"{filePath}/{filename}_{phone}.png";
//       //     qrCodeImage.Save(path);
//            string fullpath = $"/Files/{idHoinghi}/{datetime}/{filename}_{phone}.png";
//            return fullpath;
//        }
//        public static Bitmap ScaleImage(Bitmap image, int maxWidth, int maxHeight)
//        {
//            var ratioX = (double)maxWidth / image.Width;
//            var ratioY = (double)maxHeight / image.Height;
//            var ratio = Math.Min(ratioX, ratioY);

//            var newWidth = (int)(image.Width * ratio);
//            var newHeight = (int)(image.Height * ratio);

//            var newImage = new Bitmap(newWidth, newHeight);

//            using (var graphics = Graphics.FromImage(newImage))
//                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

//            return newImage;
//        }
//        private static Bitmap ResizeImage(Bitmap b, int nWidth, int nHeight)
//        {
//            var newImage = new Bitmap(nWidth, nHeight);
//            using (Graphics graphics = Graphics.FromImage(newImage))
//            {
//                graphics.SmoothingMode = SmoothingMode.AntiAlias;
//                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
//                graphics.PageUnit = GraphicsUnit.Millimeter;
//                graphics.DrawImage(b, 0, 0, nWidth, nHeight);
//            }
//            return newImage;
//        }

//        public static string RandomString(int length)
//        {
//            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
//            return new string(Enumerable.Repeat(chars, length)
//              .Select(s => s[random.Next(s.Length)]).ToArray());
//        }
//    }
//}
