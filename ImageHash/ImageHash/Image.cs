using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _image = (System.Drawing.Image)Bitmap;
        }


        public void ChangeGrayscale()
        {

            Bitmap grayBitmap = new Bitmap(Bitmap.Width, Bitmap.Height);

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

            //            //グレースケールの描画先となるImageオブジェクトを作成
            //            Bitmap newImg = new Bitmap(img.Width, img.Height);
            //            //newImgのGraphicsオブジェクトを取得
            //            Graphics g = Graphics.FromImage(newImg);
            //
            //            //ColorMatrixオブジェクトの作成
            //            //グレースケールに変換するための行列を指定する
            //            System.Drawing.Imaging.ColorMatrix cm =
            //                new System.Drawing.Imaging.ColorMatrix(
            //                    new float[][]{
            //                        new float[]{0.299f, 0.299f, 0.299f, 0 ,0},
            //                        new float[]{0.587f, 0.587f, 0.587f, 0, 0},
            //                        new float[]{0.114f, 0.114f, 0.114f, 0, 0},
            //                        new float[]{0, 0, 0, 1, 0},
            //                        new float[]{0, 0, 0, 0, 1}
            //                    });
            //            //ImageAttributesオブジェクトの作成
            //            System.Drawing.Imaging.ImageAttributes ia =
            //                new System.Drawing.Imaging.ImageAttributes();
            //            //ColorMatrixを設定する
            //            ia.SetColorMatrix(cm);
            //
            //            //ImageAttributesを使用してグレースケールを描画
            //            g.DrawImage(img,
            //                new Rectangle(0, 0, img.Width, img.Height),
            //                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            //
            //            //リソースを解放する
            //            g.Dispose();
            //
            //            return newImg;
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

                    if (basePixcel < targetPixcel)
                        hash.Add(0);
                    else 
                        hash.Add(1);
                }
            }

            return hash.ToArray();
        }


        public long GetDHashByLong()
        {
            var hash = new List<byte>();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var basePixcel = GetRByPixcel(x, y);
                    var targetPixcel = GetRByPixcel(x + 1, y);

                    if (basePixcel < targetPixcel)
                        hash.Add(0);
                    else
                        hash.Add(1);
                }
            }

            return BitConverter.ToInt64(hash.ToArray(), 0);
        }










        //        public void ChangeGrayscale()
        //        {
        //
        //        }



    }
}
