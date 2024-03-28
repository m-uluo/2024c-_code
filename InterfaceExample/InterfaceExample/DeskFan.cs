using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    public class DeskFan
    {
        private IPowerSupply _powerSupply;
        public DeskFan(IPowerSupply powerSupply) 
        {
            _powerSupply = powerSupply;
        }
        public string Work()
        {
            if (this._powerSupply.GetPower() <= 0)
                return "Won't work.";
            else if (this._powerSupply.GetPower() <= 100)
                return "Slow.";
            else if (this._powerSupply.GetPower() <= 200)
                return "Work fine.";
            else
                return "Warning!";
        }
    }
}
