using System;

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
    }
}
