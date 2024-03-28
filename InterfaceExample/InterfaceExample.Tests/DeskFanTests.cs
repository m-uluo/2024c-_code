using Moq;

namespace InterfaceExample.Tests
{
    public class DeskFanTests
    {
        [Fact]
        public void PowerLowerThanZero_OK()
        {
            DeskFan fan = new DeskFan(new PowerLowerThanZero());
            var expected = "Won't work.";
            var actual = fan.Work();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PowerSupplyHightThan200_Warning()
        {
            DeskFan fan = new DeskFan(new PowerSupplyHightThan200());
            var expected = "Warning!";
            var actual = fan.Work();
            Assert.Equal(expected, actual);
        }
    }
    class PowerLowerThanZero : IPowerSupply
    {
        private int _power;
        public PowerLowerThanZero()

        {
            this._power = 0;
        }
        public int GetPower()
        {
            return this._power;
        }
    }
    class PowerSupplyHightThan200 : IPowerSupply
    {
        private int _power;
        public PowerSupplyHightThan200() 
        {
            _power = 201;
        }

        public int GetPower()
        {
            return this._power;
        }
    }
}