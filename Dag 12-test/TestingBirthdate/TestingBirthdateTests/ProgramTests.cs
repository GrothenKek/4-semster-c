using NUnit.Framework;

namespace TestingBirthdate.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [TestCase(19,2112714811)]
        public void getCenturyFromCPRTest(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }
    }
}