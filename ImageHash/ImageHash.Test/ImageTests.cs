using System;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageHash.Test
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void 画像サイズ取得テスト()
        {
            var imgData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_1.jpg");
            var img = new ImageHash.Image(imgData);

            img.Height.Is(1200);
            img.Width.Is(1920);
        }

        [TestMethod]
        public void 画像サイズ変更テスト()
        {
            var imgData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_1.jpg");
            var img = new ImageHash.Image(imgData);
            img.Resize(new Size(9,8));


            img.Height.Is(8);
            img.Width.Is(9);
        }



        [TestMethod]
        public void R値取得テスト_黒()
        {
            var imgData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_black.jpg");
            var img = new ImageHash.Image(imgData);
            img.Resize(new Size(9, 8));


            byte argb = img.GetRByPixcel(0, 0);
            argb.Is((byte)0);
        }

        [TestMethod]
        public void R値取得テスト_白()
        {
            var imgData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_white.jpg");
            var img = new ImageHash.Image(imgData);
            img.Resize(new Size(9, 8));


            byte argb = img.GetRByPixcel(0, 0);
            argb.Is((byte)254);
        }


        [TestMethod]
        public void ハッシュ値取得テスト_黒()
        {
            var imgData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_black.jpg");
            var img = new ImageHash.Image(imgData);
            img.Resize(new Size(9, 8));

            var hash = img.GetDHash();
            foreach (var b in hash)
            {
                b.Is((byte)1);
            }

            img.GetDHashByLong().Is(72340172838076673);
        }

        [TestMethod]
        public void ハッシュ値取得テスト_黒_Grayscale処理()
        {
            var imgData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_black.jpg");
            var img = new ImageHash.Image(imgData);
            img.Resize(new Size(9, 8));
            img.ChangeGrayscale();

            var hash = img.GetDHash();
            foreach (var b in hash)
            {
                b.Is((byte)1);
            }

            img.GetDHashByLong().Is(72340172838076673);

        }

    }
}
