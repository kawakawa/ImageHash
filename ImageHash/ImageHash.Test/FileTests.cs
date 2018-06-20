using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageHash.Test
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public void ファイル存在テスト_存在するファイル指定()
        {
            var exists = ImageHash.File.Exists("./TestFiles/SampleImages/image_1.jpg");
            exists.IsTrue();
        }

        [TestMethod]
        public void ファイル存在テスト_存在しないファイル指定()
        {
            var exists = ImageHash.File.Exists("./Dummy.jpg");
            exists.IsFalse();
        }


        [TestMethod]
        public void ファイル存在テスト_フォルダを指定()
        {
            var exists = ImageHash.File.Exists("./TestFiles/");
            exists.IsFalse();
        }


        [TestMethod]
        public void Imageデータ取得テスト_存在するファイル指定()
        {
            var imageData = ImageHash.File.GetImage("./TestFiles/SampleImages/image_1.jpg");
            imageData.IsNotNull();
            imageData.Height.Is(1200);
            imageData.Width.Is(1920);
        }

        [TestMethod]
        public void Imageデータ取得テスト_存在しないファイル指定()
        {
            var imageData = ImageHash.File.GetImage("./Dummy.jpg");
            imageData.IsNull();
        }

        [TestMethod]
        public void Imageデータ取得テスト_画材ファイル以外を指定()
        {
            var imageData = ImageHash.File.GetImage("./TestFiles/NonImageFiles/sample.txt");
            imageData.IsNull();
        }
    }
}
