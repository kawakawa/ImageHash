using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageHash
{
    public class Image
    {
        private System.Drawing.Image _image;
        private Bitmap _bitmap;

        public Bitmap Bitmap
        {
            set => _bitmap = value;
            get
            {
                if (_bitmap != null)
                    return _bitmap;

                _bitmap = new Bitmap(_image, new Size(_image.Width,_image.Height));
                return _bitmap;
            }
        }



        public int Height => _image.Height;

        public int Width => _image.Width;


        public Image(System.Drawing.Image image)
        {
            _image = image;
        }


        /// <summary>
        /// サイズ変更
        /// </summary>
        /// <param name="newSize"></param>
        public void Resize(Size newSize)
        {
            Bitmap = new Bitmap(_image,newSize);
            _image = Bitmap;
        }


        public void ChangeGrayscale()
        {

            var grayBitmap = new Bitmap(Bitmap.Width, Bitmap.Height);

            for (int x = 0; x < Bitmap.Width; x++)
            {
                for (int y = 0; y < Bitmap.Height; y++)
                {
                    Color oc = Bitmap.GetPixel(x, y);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    grayBitmap.SetPixel(x, y, nc);
                }
            }

            Bitmap = grayBitmap;
        }







        /// <summary>
        /// 指定Pixcel位置のArgb値を取得
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public byte GetRByPixcel(int x, int y)
        {
            if (_bitmap == null)
                return 0;

            if (_bitmap.Height < y)
                return 0;

            if (_bitmap.Width < x)
                return 0;

            var pixelColor = _bitmap.GetPixel(x, y);
            return  pixelColor.R;
        }



        public byte[] GetDHash()
        {
            var hash = new List<byte>();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var basePixcel = GetRByPixcel(x,y);
                    var targetPixcel = GetRByPixcel(x+1, y);

                    hash.Add(basePixcel < targetPixcel ? (byte) 0 : (byte) 1);
                }
            }

            return hash.ToArray();
        }


        public long GetDHashByLong()
        {
            var bin = GetDHash();
            return BitConverter.ToInt64(bin, 0);
        }


    }
}
