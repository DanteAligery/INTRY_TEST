using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTRY.MISC

{
    [TestFixture]
    class TestData
    {

        static String CorrectUserName = "lesnikov";
        static String IncorrectUserName = "qwerty";
        static String CorrectUserPWD = "qoO5QOE9";
        static String IncorrectUserPWD = "HOHOHO";

        
        public static IEnumerable<TestCaseData> loginTestData
        {
            get
            {
                yield return new TestCaseData(CorrectUserName, CorrectUserPWD, "OK");
                yield return new TestCaseData(IncorrectUserName, CorrectUserPWD, "Unauthorized");
                yield return new TestCaseData(CorrectUserName, IncorrectUserPWD, "Unauthorized");
                yield return new TestCaseData(IncorrectUserName, IncorrectUserPWD, "Unauthorized");
            }
        }
    }
}
