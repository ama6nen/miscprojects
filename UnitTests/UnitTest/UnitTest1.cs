using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting1;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private static Random random = new Random();
        public static string RandomLetters(int length)
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnm";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomOthers(int length)
        {
            const string chars = "0123456789+.,-->'¨¨+?`?``!#¤%&/()";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [TestMethod]
        public void Test_TestClass()
        {
            TestClass instance = new TestClass();
            Assert.AreEqual(0, instance.GetCorrectedData(), "incorrect default value");
            Assert.AreEqual(String.Empty, instance.GetLettersOnly(), "incorrect default value");

            for(int i = 0; i < 100; i++)
            {
                var str = RandomLetters(random.Next(0, 10));
                instance.SetLettersOnly(str);
                Assert.AreEqual(str, instance.GetLettersOnly(), "incorrect set letters value (valid input)");
            }

            for (int i = 0; i < 100; i++)
            {
                var str = RandomOthers(random.Next(0, 10));
                instance.SetLettersOnly(str);
                Assert.AreEqual(String.Empty, instance.GetLettersOnly(), "incorrect set letters value (invalid input)");
            }
            for (int i = 0; i < 500; i+=5)
            {
                instance.SetSomeData(i);
                if(i < 100)
                    Assert.IsTrue(instance.GetCorrectedData() == i, "Input has not been set properly. (mismatch");
                Assert.IsTrue(instance.GetCorrectedData() <= 100, "Input has not been corrected properly. (over 100)");
                Assert.IsTrue(instance.GetCorrectedData() >= 0, "Input has not been corrected properly. (less than 0)");
            }
          
        }
    }
}
