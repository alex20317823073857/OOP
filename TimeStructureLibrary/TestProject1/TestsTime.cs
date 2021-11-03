using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TimeStructureLibrary;
namespace TestProject1
{
    [TestClass]
    public class TestsTime
    {
        [TestClass]
        public class TimeUnitTests
        {
            [TestMethod]
            public void ConstructorTestMethod()
            {
                var myTime = CreateTestTime();

                int ds = 12 * 3600 + 34 * 60 + 56;

                Assert.AreEqual(12, myTime.Hours);
                Assert.AreEqual(34, myTime.Minutes);
                Assert.AreEqual(56, myTime.Seconds);
                Assert.AreEqual(ds, myTime.DurationInSeconds);
            }

            [TestMethod]
            public void ToStringTestMethod()
            {
                Assert.AreEqual("12:34:56", CreateTestTime().ToString());
            }

            [TestMethod]
            public void DisplayTestMethod()
            {
                var t1 = CreateTestTime();
                var t2 = new Time(23, 50, 16);

                var consoleOut = new[]
                {
                "Структура Time, 12:34:56",
                "Структура Time, 23:50:16",
                };

                TextWriter oldOut = Console.Out;

                StringWriter output = new StringWriter();
                Console.SetOut(output);

                t1.Display();
                t2.Display();

                Console.SetOut(oldOut);

                var outputArray = output.ToString().Split(new[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(2, outputArray.Length);
                for (var i = 0; i < consoleOut.Length; i++)
                    Assert.AreEqual(consoleOut[i], outputArray[i]);
            }

            [TestMethod]
            public void EqualsTestMethod()
            {
                Time t1 = new Time(12, 34, 56);
                Time t1b = new Time(12, 34, 56);

                Time t2 = new Time(12, 34, 55);

                Assert.AreEqual(true, t1.Equals(t1b));
                Assert.AreEqual(false, t1.Equals(t2));
            }

            [TestMethod]
            public void AdditionTestMethod()
            {
                Time t1 = new Time(1, 2, 3);

                Time t2 = new Time(10, 12, 4);

                var t3 = t1 + t2;

                Assert.AreEqual("11:14:07", t3.ToString());
            }

            [TestMethod]
            public void SubTestMethod()
            {
                Time t1 = new Time(1, 2, 3);

                Time t2 = new Time(10, 12, 4);

                var t3 = t2 - t1;

                Assert.AreEqual("09:10:01", t3.ToString());

            }

            [TestMethod]
            public void MultTestMethod()
            {
                Time t1 = new Time(1, 2, 3);

                int x = 5;

                Time t2 = t1 * x;

                Assert.AreEqual("05:10:15", t2.ToString());

            }
            private Time CreateTestTime()
            {
                return new Time(12, 34, 56);
            }
        }
    }
}
