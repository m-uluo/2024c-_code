using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    public class PowerSupply : IPowerSupply
    {
        private int _power;
        public PowerSupply()

        {
            this._power = 120;
        }
        public int GetPower()
        {
            return this._power;
        }
    }
}
