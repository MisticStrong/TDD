namespace StringCalculatorTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StringCalculator;

    [TestClass]
    public class StringCalculatorTest
    {
        private StringCalculator stringCalculator;

        [TestInitialize]
        public void Setup()
        {
            this.stringCalculator = new StringCalculator();
        }

        [TestMethod]
        public void EmptystringShouldReturnZero()
        {
            var resultAdd = this.stringCalculator.Add("");

            Assert.AreEqual("0", resultAdd);
        }

        [TestMethod]
        public void StringWithNumberOneShouldReturnOne()
        {
            var resultAdd = this.stringCalculator.Add("1");

            Assert.AreEqual("1", resultAdd);
        }

        [TestMethod]
        public void StringWithTwoNumbersShouldReturnSum()
        {
            var resultAdd = this.stringCalculator.Add("1,2");

            Assert.AreEqual("3", resultAdd);
        }

        [TestMethod]
        public void StringWithTreeNumbersShouldReturnSum()
        {
            var resultAdd = this.stringCalculator.Add("1.1,2.2,1.2");

            Assert.AreEqual("4.5", resultAdd);
        }

        [TestMethod]
        public void StringWithNewLineSeparator()
        {
            var resultAdd = this.stringCalculator.Add("1\n2,3");

            Assert.AreEqual("6", resultAdd);
        }

        [TestMethod]
        public void StringWithNewLineAndFloatNumbers()
        {
            var resultAdd = this.stringCalculator.Add("175.2,\n35");

            Assert.AreEqual("Number expected but '\n' found at position 6.", resultAdd);
        }

        [TestMethod]
        public void ErrorTwoSeparatorTogetherFloatNumbers()
        {
            var resultAdd = this.stringCalculator.Add("175.2,20\n,35");

            Assert.AreEqual("Number expected but ',' found at position 9.", resultAdd);
        }

        [TestMethod]
        public void EndWithSeparator()
        {
            var resultAdd = this.stringCalculator.Add("12,13,");

            Assert.AreEqual("Number expected but EOF found.", resultAdd);
        }

        [TestMethod]
        public void CustomSeparators()
        {
            var resultAdd = this.stringCalculator.Add("//;\n1;2");

            Assert.AreEqual("3", resultAdd);
        }

        [TestMethod]
        public void AnotherCustomSeparators()
        {
            var resultAdd = this.stringCalculator.Add("//|\n1|2|3");

            Assert.AreEqual("6", resultAdd);
        }

        [TestMethod]
        public void AnotherCustomSeparator()
        {
            var resultAdd = this.stringCalculator.Add("//sep\n2sep3");

            Assert.AreEqual("5", resultAdd);
        }

        [TestMethod]
        public void CustomSeparatorWithWrongseparator()
        {
            var resultAdd = this.stringCalculator.Add("//|\n1|2,3");

            Assert.AreEqual("'|' expected but ',' found at position 3.", resultAdd);
        }
    }
}