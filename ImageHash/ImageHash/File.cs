using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ImageHash
{
    public class File
    {
        /// <summary>
        /// 指定ファイルが存在するか
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            var fileInfo = new System.IO.FileInfo(path);
            

            return fileInfo.Exists;
        }


        /// <summary>
        /// Imageデータ取得
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static System.Drawing.Image GetImage(string path)
        {
            if(Exists(path)==false)
                return null;

            try
            {
                var img = System.Drawing.Image.FromFile(path);
                return img;
            }
            catch (OutOfMemoryException)
            {
                //画像ファイル以外はNullを返す
                return null;
            }

        }

        /// <summary>
        /// Imageデータ保存
        /// </summary>
        /// <param name="image"></param>
        /// <param name="path"></param>
        public static void SaveImage(ImageHash.Image image,string path)
        {
            var bitmap = image.Bitmap;
            bitmap.Save(
                path,
                System.Drawing.Imaging.ImageFormat.Bmp
            );
        }


    }
}
