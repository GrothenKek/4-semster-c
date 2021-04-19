using ClassLibrary1.DataContext;
using ClassLibrary1.Model;
using ClassLibrary1.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarytest1
{
    public class Class1
    {

        public double CalculatePrice(PriceModel model)
        {
            using (RentServiceDBContext db = new RentServiceDBContext())
            {
                Tool selectedTool = db.Tools.Find(model.ToolID);
                int difference = (model.EndDate - model.StartDate).Days;
                double calculatedPrice = difference * selectedTool.PricePrDay;

                return calculatedPrice;

            }
        }
    }
    public class Tests
    {
        Class1 c1;
        PriceModel p1;
        PriceModel p2;
        PriceModel p3;
        PriceModel p4;
        PriceModel p5;

        [SetUp]
        public void Setup()
        {
            c1 = new Class1();
            p1 = new PriceModel();
            p1.EndDate = new DateTime(2021, 4, 13);
            p1.StartDate = new DateTime(2021, 4, 12);
            p1.ToolID = 1;

            p2 = new PriceModel();
            p2.EndDate = new DateTime(2021, 4, 13);
            p2.StartDate = new DateTime(2021, 4, 12);
            p2.ToolID = 2;

            p3 = new PriceModel();
            p3.EndDate = new DateTime(2021, 4, 13);
            p3.StartDate = new DateTime(2021, 4, 12);
            p3.ToolID = 3;

            p4 = new PriceModel();
            p4.EndDate = new DateTime(2021, 4, 13);
            p4.StartDate = new DateTime(2021, 4, 12);
            p4.ToolID = 4;

            p5 = new PriceModel();
            p5.EndDate = new DateTime(2021, 4, 13);
            p5.StartDate = new DateTime(2021, 4, 12);
            p5.ToolID = 5;


        }



        [Test]
        public void Test1DayAllTools()
        {
            Assert.That(c1.CalculatePrice(p1), Is.EqualTo(200));
            Assert.That(c1.CalculatePrice(p2), Is.EqualTo(250));
            Assert.That(c1.CalculatePrice(p3), Is.EqualTo(300));
            Assert.That(c1.CalculatePrice(p4), Is.EqualTo(400));
            Assert.That(c1.CalculatePrice(p5), Is.EqualTo(450));

        }
    }


    public class Test2Days
    {
        Class1 c1;
        PriceModel p1;
        PriceModel p2;
        PriceModel p3;
        PriceModel p4;
        PriceModel p5;

        [SetUp]
        public void Setup()
        {
            c1 = new Class1();
            p1 = new PriceModel();
            p1.EndDate = new DateTime(2021, 4, 14);
            p1.StartDate = new DateTime(2021, 4, 12);
            p1.ToolID = 1;

            p2 = new PriceModel();
            p2.EndDate = new DateTime(2021, 4, 14);
            p2.StartDate = new DateTime(2021, 4, 12);
            p2.ToolID = 2;

            p3 = new PriceModel();
            p3.EndDate = new DateTime(2021, 4, 14);
            p3.StartDate = new DateTime(2021, 4, 12);
            p3.ToolID = 3;

            p4 = new PriceModel();
            p4.EndDate = new DateTime(2021, 4, 14);
            p4.StartDate = new DateTime(2021, 4, 12);
            p4.ToolID = 4;

            p5 = new PriceModel();
            p5.EndDate = new DateTime(2021, 4, 14);
            p5.StartDate = new DateTime(2021, 4, 12);
            p5.ToolID = 5;


        }
        [Test]
        public void Test2DayAllTools()
        {
            Assert.That(c1.CalculatePrice(p1), Is.EqualTo(400));
            Assert.That(c1.CalculatePrice(p2), Is.EqualTo(500));
            Assert.That(c1.CalculatePrice(p3), Is.EqualTo(600));
            Assert.That(c1.CalculatePrice(p4), Is.EqualTo(800));
            Assert.That(c1.CalculatePrice(p5), Is.EqualTo(900));

        }

    }
    public class Test7DaysPlus
    {
        Class1 c1;
        PriceModel p1;
        PriceModel p2;
        PriceModel p3;
        PriceModel p4;
        PriceModel p5;

        [SetUp]
        public void Setup()
        {
            c1 = new Class1();
            p1 = new PriceModel();
            p1.EndDate = new DateTime(2021, 4, 21);
            p1.StartDate = new DateTime(2021, 4, 12);
            p1.ToolID = 1;

            p2 = new PriceModel();
            p2.EndDate = new DateTime(2021, 4, 22);
            p2.StartDate = new DateTime(2021, 4, 12);
            p2.ToolID = 2;

            p3 = new PriceModel();
            p3.EndDate = new DateTime(2021, 4, 19);
            p3.StartDate = new DateTime(2021, 4, 12);
            p3.ToolID = 3;

            p4 = new PriceModel();
            p4.EndDate = new DateTime(2021, 4, 25);
            p4.StartDate = new DateTime(2021, 4, 12);
            p4.ToolID = 4;

            p5 = new PriceModel();
            p5.EndDate = new DateTime(2021, 4, 30);
            p5.StartDate = new DateTime(2021, 4, 12);
            p5.ToolID = 5;


        }
        [Test]
        public void Test7plusDayAllTools()
        {
            Assert.That(c1.CalculatePrice(p1), Is.EqualTo(200*9));
            Assert.That(c1.CalculatePrice(p2), Is.EqualTo(250*10));
            Assert.That(c1.CalculatePrice(p3), Is.EqualTo(300*7));
            Assert.That(c1.CalculatePrice(p4), Is.EqualTo(400*13));
            Assert.That(c1.CalculatePrice(p5), Is.EqualTo(450*18));

        }

    }
}
