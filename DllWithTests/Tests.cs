using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallTestFramework;

namespace DllWithTests
{
    [TestClass]
    class TestClass
    {
        private string innerItem = "";

        [TestStart]
        public void TestStart()
        {
            innerItem = innerItem + "Inner item changed.";
        }

        [TestMethod]
        public void TestSmth()
        {
            Console.WriteLine("testing something " + innerItem);
        }



        [TestStop]
        public void TestStop()
        {
            //innerItem = "Inner item changed.";
        }
    }

}
