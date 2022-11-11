using UnitTest.Domain;

namespace UnitTest.Tests
{
    public class PrimeServiceTest
    {
        [Theory]
        [InlineData(5,true)]
        [InlineData(12,false)]
        public void IsPrime_ForLowerThanTwo_ToBeFalse(int number)
        {
            //arrange
            var sut = new PrimeService();

            //action
            var result = sut.IsPrime(number);

            //assert
            Assert.False(result);
        }
    }
}