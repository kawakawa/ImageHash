using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static Image GetImage(string path)
        {
            if(Exists(path)==false)
                return null;

            var  img = Image.FromFile(path);
            return img;
        }


    }
}
