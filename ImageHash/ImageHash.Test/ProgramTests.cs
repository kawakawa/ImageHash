using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageHash.Test
{
    [TestClass]
    public class ProgramTests
    {

        [TestMethod]
        public void ハッシュ値取得_黒()
        {
            var hash = ImageHash.Program.GetImgHashLong("./TestFiles/SampleImages/image_black.jpg");
            hash.Is(72340172838076673);
        }


        [TestMethod]
        public void ハッシュ値取得_白()
        {
            var hash = ImageHash.Program.GetImgHashLong("./TestFiles/SampleImages/image_white.jpg");
            hash.Is(72340172838076672);
        }


        [TestMethod]
        public void ハッシュ値取得_1()
        {
            var hash = ImageHash.Program.GetImgHashLong("./TestFiles/SampleImages/image_1.jpg");
            hash.Is(72339069031481600);
        }


        [TestMethod]
        public void ハミング距離テスト_黒と黒_同一ファイル()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_black.jpg",
                "./TestFiles/SampleImages/image_black.jpg");

            hammingDistance.Is(0);

        }


        [TestMethod]
        public void ハミング距離テスト_同一ファイル()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_1.jpg",
                "./TestFiles/SampleImages/image_1.jpg");

            hammingDistance.Is(0);
        }


        [TestMethod]
        public void ハミング距離テスト_黒と白()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_black.jpg",
                "./TestFiles/SampleImages/image_white.jpg");

            hammingDistance.Is(8);

        }

        [TestMethod]
        public void ハミング距離テスト_1と2()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_1.jpg",
                "./TestFiles/SampleImages/image_2.jpg");

            hammingDistance.Is(31);
        }

        [TestMethod]
        public void ハミング距離テスト_1と3()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_1.jpg",
                "./TestFiles/SampleImages/image_3.jpg");

            hammingDistance.Is(2);
        }

        [TestMethod]
        public void ハミング距離テスト_4と5()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_4.jpg",
                "./TestFiles/SampleImages/image_5.jpg");

            hammingDistance.Is(32);
        }
        [TestMethod]
        public void ハミング距離テスト_4と6()
        {
            var hammingDistance = ImageHash.Program.GetHammingDistance(
                "./TestFiles/SampleImages/image_4.jpg",
                "./TestFiles/SampleImages/image_6.jpg");

            hammingDistance.Is(31);
        }
    }
}
