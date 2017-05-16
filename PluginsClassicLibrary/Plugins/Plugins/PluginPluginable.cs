using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class PluginPluginable<T> : IMyltiply where T : IMyltiply
    {
        private int _intData = 2;
        public int IntDataForMyltipy
        {
            get
            {
                return _intData;
            }
            set
            {
                _intData = value;
            }
        }
        public IMyltiply MyltiplyNumber(IMyltiply number)
        {
            this.IntDataForMyltipy = this.IntDataForMyltipy * 2;
            number.IntDataForMyltipy = number.IntDataForMyltipy * 2;
            return number;
        }
    }
}
