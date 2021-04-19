using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestConsoleApp
{
    [TestFixture]
    class TestClass
    {
        Calculator calc;

        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }

        [Test]
        public void SubstractTest()
        {
            Assert.AreEqual(-2, calc.substract(4, 6));
        }

        [TestCase(10, 4, 6)]
        [TestCase(16, 10, 6)]
        public void SumTest(int result, int v1, int v2)
        {
            Assert.That(calc.add(v1, v2), Is.EqualTo(result));
        }

        [Test]
        public void DivisionTest()
        {
            Assert.Throws<DivideByZeroException>(() => calc.div(4, 0));
        }


        [Test]
        public void MultiplyTest()
        {
            Assert.AreEqual(4, calc.mul(2, 2));
        }
    }

    [TestFixture]
    class TestFraction
    {
        FractionCalculator calc;
        FractionCalculator.Fraction f1 = new FractionCalculator.Fraction(3, 2);
        FractionCalculator.Fraction f2 = new FractionCalculator.Fraction(6, 4);
        FractionCalculator.Fraction f3 = new FractionCalculator.Fraction(8, 6);
        FractionCalculator.Fraction f4 = new FractionCalculator.Fraction(10, 8);
        FractionCalculator.Fraction res = new FractionCalculator.Fraction(24, 8);

        [SetUp]
        public void SetUp()
        {
         calc = new FractionCalculator();
        
        }


        [Test]
        public void addTest()
        {
            Assert.AreEqual(res.Numerator1, calc.Add(f1 , f2 ).Numerator1);
            Assert.AreEqual(res.Denominator1, calc.Add(f1, f2).Denominator1);

        }


    }
}
