using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BusinessLogic;
using PIS_Lab1;
using NUnit.Framework.Legacy;
using System.Reflection;

namespace Tests
{
    [TestFixture]
    public class LogicTests
    {
        ////[Test]
        ////public void ParseSea_ValidInput_ReturnsCorrectObject()
        ////{
        ////    string input = "'SeaName' 100 35";
        ////    Sea sea = Logic.ParseSea(input);
        ////    ClassicAssert.AreEqual("SeaName", sea.name);
        ////    ClassicAssert.AreEqual(100, sea.depth);
        ////    ClassicAssert.AreEqual(35, sea.salinity);
        ////}

        [Test]
        public void ParseSea_ValidInput_ReturnsCorrectObject()
        {
            string input = "'SeaName' 100 35";
            Sea sea = Logic.ParseSea(input);
            Sea goodSea = new Sea("SeaName", 100.0, 35.0);
            ClassicAssert.AreEqual(goodSea, sea);

            //object[] expectedValues = { "SeaName", 100.0, 35.0 };

            //PropertyInfo[] properties = typeof(Sea).GetProperties().Where(p => p.Name == nameof(sea.name) || p.Name == nameof(sea.depth) || p.Name == nameof(sea.salinity)).ToArray();

            //for (int i = 0; i < properties.Length; i++)
            //{
            //    object actualValue = properties[i].GetValue(sea);
            //    ClassicAssert.AreEqual(expectedValues[i], actualValue);
            //}
        }


        [Test]
        public void ParseSea_InvalidInput_MissingData_ThrowsArgumentException()
        {
            string input = "'SeaName' 100";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }

        [Test]
        public void ParseSea_InvalidInput_NonNumericDepth_ThrowsArgumentException()
        {
            string input = "'SeaName' abc 35";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }

        [Test]
        public void ParseSea_InvalidInput_NonNumericSalinity_ThrowsArgumentException()
        {
            string input = "'SeaName' 100 def";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }

        //[Test]
        //public void ParseInlandSea_ValidInput_ReturnsCorrectObject()
        //{
        //    string input = "'InlandSeaName' 50 25 10";
        //    Sea sea = Logic.ParseSea(input);
        //    ClassicAssert.IsInstanceOf<InlandSea>(sea);
        //    InlandSea inlandSea = (InlandSea)sea;
        //    ClassicAssert.AreEqual("InlandSeaName", inlandSea.name);
        //    ClassicAssert.AreEqual(50, inlandSea.depth);
        //    ClassicAssert.AreEqual(25, inlandSea.salinity);
        //    ClassicAssert.AreEqual(10, inlandSea.countCountries);
        //}
        [Test]
        public void ParseInlandSea_ValidInput_ReturnsCorrectObject()
        {
            string input = "'InlandSeaName' 50 25 10";
            InlandSea inlandSea = (InlandSea)Logic.ParseSea(input);
            InlandSea goodInlandSea = new InlandSea("InlandSeaName", 50, 25, 10);
            ClassicAssert.AreEqual(goodInlandSea, inlandSea);

            //string input = "'InlandSeaName' 50 25 10";
            //Sea sea = Logic.ParseSea(input);
            //InlandSea inlandSea = (InlandSea)sea;

            //object[] expectedValues = { "InlandSeaName", 50, 25, 10};
            //PropertyInfo[] properties = typeof(InlandSea).GetProperties().Where(p => p.Name == nameof(inlandSea.name) || p.Name == nameof(inlandSea.depth) || p.Name == nameof(inlandSea.salinity) || p.Name == nameof(inlandSea.countCountries)).ToArray();

            //for (int i = 0; i < properties.Length; i++)
            //{
            //    object actualValue = properties[i].GetValue(inlandSea);
            //    ClassicAssert.AreEqual(expectedValues[i], actualValue);
            //}
        }

        [Test]
        public void ParseInlandSea_InvalidInput_MissingData_ThrowsArgumentException()
        {
            string input = "'InlandSeaName' 50";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }

        [Test]
        public void ParseInlandSea_InvalidInput_NonNumericCount_ThrowsArgumentException()
        {
            string input = "'InlandSeaName' 50 25 xyz";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }


        //[Test]
        //public void ParseMarginalSeas_ValidInput_ReturnsCorrectObject()
        //{

        //    string input = "'MarginalSeaName' 75 30 true";
        //    Sea sea = Logic.ParseSea(input);
        //    ClassicAssert.IsInstanceOf<MarginalSeas>(sea); // Используйте подходящий для вас фреймворк утверждений
        //    MarginalSeas marginalSeas = (MarginalSeas)sea;
        //    ClassicAssert.AreEqual("MarginalSeaName", marginalSeas.name);
        //    ClassicAssert.AreEqual(75, marginalSeas.depth);
        //    ClassicAssert.AreEqual(30, marginalSeas.salinity);
        //    ClassicAssert.IsTrue(marginalSeas.portАvailability);
        //}

        [Test]
        public void ParseMarginalSeas_ValidInput_ReturnsCorrectObject()
        {
            string input = "'MarginalSeaName' 75 30 true";
            MarginalSeas marginalSeas = (MarginalSeas)Logic.ParseSea(input);
            MarginalSeas goodMarginalSeas = new MarginalSeas("'MarginalSeaName", 75, 30, true);
            ClassicAssert.AreEqual(goodMarginalSeas, marginalSeas);

            //string input = "'MarginalSeaName' 75 30 true";
            //Sea sea = Logic.ParseSea(input);
            //MarginalSeas marginalSeas = (MarginalSeas)sea;

            //object[] expectedValues = { "MarginalSeaName", 75, 30, true };
            //PropertyInfo[] properties = typeof(MarginalSeas).GetProperties().Where(p => p.Name == nameof(marginalSeas.name) || p.Name == nameof(marginalSeas.depth) || p.Name == nameof(marginalSeas.salinity) || p.Name == nameof(marginalSeas.portАvailability)).ToArray();

            //for (int i = 0; i < properties.Length; i++)
            //{
            //    object actualValue = properties[i].GetValue(marginalSeas);
            //    ClassicAssert.AreEqual(expectedValues[i], actualValue);
            //}
        }

        [Test]
        public void ParseMarginalSeas_InvalidInput_MissingData_ThrowsArgumentException()
        {
            string input = "'MarginalSeaName' 75"; 
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }

        [Test]
        public void ParseMarginalSeas_InvalidInput_NonBooleanPort_ThrowsArgumentException()
        {
            string input = "'MarginalSeaName' 75 30 maybe";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }

        [Test]
        public void ParseMarginalSeas_InvalidInput_EmptyName_ThrowsArgumentException()
        {
            string input = "'' 75 30 true";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));
        }


        [Test]
        public void ParseMarginalSeas_InvalidInput_MissingQuotes_ThrowsArgumentException()
        {
            string input = "MarginalSeaName 75 30 true";
            Assert.Throws<ArgumentException>(() => Logic.ParseSea(input));

        }

        //[Test]
        //public void ParseInlandSea_ValidInput_ReturnsCorrectObject()
        //{
        //    string input = "'InlandSeaName' 50 25 10";
        //    InlandSea inlandSea = Logic.ParseInlandSea(input);
        //    ClassicAssert.AreEqual("InlandSeaName", inlandSea.name);
        //    ClassicAssert.AreEqual(50, inlandSea.depth);
        //    ClassicAssert.AreEqual(25, inlandSea.salinity);
        //    ClassicAssert.AreEqual(10, inlandSea.countCountries);
        //}

        //[Test]
        //public void ParseInlandSea_InvalidInput_MissingData_ThrowsArgumentException()
        //{
        //    string input = "'InlandSeaName' 50 25";
        //    Assert.Throws<ArgumentException>(() => Logic.ParseInlandSea(input));
        //}

        //[Test]
        //public void ParseInlandSea_InvalidInput_NonNumericCount_ThrowsArgumentException()
        //{
        //    string input = "'InlandSeaName' 50 25 xyz";
        //    Assert.Throws<ArgumentException>(() => Logic.ParseInlandSea(input));
        //}


        //[Test]
        //public void ParseMarginalSeas_ValidInput_ReturnsCorrectObject()
        //{
        //    string input = "'MarginalSeaName' 75 30 true";
        //    MarginalSeas marginalSeas = Logic.ParseMarginalSeas(input);
        //    ClassicAssert.AreEqual("MarginalSeaName", marginalSeas.name);
        //    ClassicAssert.AreEqual(75, marginalSeas.depth);
        //    ClassicAssert.AreEqual(30, marginalSeas.salinity);
        //    ClassicAssert.IsTrue(marginalSeas.portАvailability);
        //}

        //[Test]
        //public void ParseMarginalSeas_InvalidInput_MissingData_ThrowsArgumentException()
        //{
        //    string input = "'MarginalSeaName' 75 30";
        //    Assert.Throws<ArgumentException>(() => Logic.ParseMarginalSeas(input));
        //}

        //[Test]
        //public void ParseMarginalSeas_InvalidInput_NonBooleanPort_ThrowsArgumentException()
        //{
        //    string input = "'MarginalSeaName' 75 30 maybe";
        //    Assert.Throws<ArgumentException>(() => Logic.ParseMarginalSeas(input));
        //}

        //[Test]
        //public void ParseMarginalSeas_InvalidInput_EmptyName_ThrowsArgumentException()
        //{
        //    string input = "'' 75 30 true";
        //    Assert.Throws<ArgumentException>(() => Logic.ParseMarginalSeas(input));
        //}


        //[Test]
        //public void ParseMarginalSeas_InvalidInput_MissingQuotes_ThrowsArgumentException()
        //{
        //    string input = "MarginalSeaName 75 30 true";
        //    Assert.Throws<ArgumentException>(() => Logic.ParseMarginalSeas(input));

        //}


    }
}
