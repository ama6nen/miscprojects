using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTesting1
{
    public class TestClass
    {
        private int SomeData = default;
        private string LettersOnly = string.Empty;
        public TestClass()
        {

        }

        public string GetLettersOnly() => LettersOnly;
        public void SetLettersOnly(string LettersOnly)
        {
            if (Regex.IsMatch(LettersOnly, @"^[a-zA-Z]+$"))
                this.LettersOnly = LettersOnly;
            else
                this.LettersOnly = String.Empty;
        }

        public int GetCorrectedData()
        {
            if (SomeData > 100)
                return 100;
            else if (SomeData < 0)
                return 0;
            else return SomeData;
        }
        public void SetSomeData(int data) => SomeData = data;

    }
}
