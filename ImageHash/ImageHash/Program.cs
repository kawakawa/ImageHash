using System;
using System.Drawing;
using System.Linq;

namespace ImageHash
{
    public class Program
    {
        static void Main(string[] args)
        {
        }


        public static int GetHammingDistance(string path1, string path2)
        {
            var img1 = File.GetImage(path1);
            var img2 = File.GetImage(path2);

            return GetHammingDistance(img1, img2);
        }


        public static int GetHammingDistance(System.Drawing.Image img1, System.Drawing.Image img2)
        {
            var img1Hash = GetImgHash(img1);
            var img2Hash = GetImgHash(img2);

            if (img1Hash.Length != img2Hash.Length)
                throw new Exception("Hash size is different");

            int unmatchCount = 0;
            for (int i = 0; i < img1Hash.Length; i++)
            {
                if (img1Hash[i] != img2Hash[i])
                    unmatchCount++;
            }

            return unmatchCount;
        }


        public static long GetImgHashLong(string path)
        {
            var hash = GetImgHash(path);
            return BitConverter.ToInt64(hash.ToArray(), 0);
        }


        public static byte[] GetImgHash(string path)
        {
            var img = File.GetImage(path);
            return GetImgHash(img);
        }


        public static byte[] GetImgHash(System.Drawing.Image img)
        {
            var imgData = new Image(img);
            imgData.Resize(new Size(9, 8));
            imgData.ChangeGrayscale();

            return imgData.GetDHash();
        }




    }
}
