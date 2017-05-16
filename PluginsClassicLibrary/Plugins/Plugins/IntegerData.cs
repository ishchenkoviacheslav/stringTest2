using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class IntegerData: BaseData<IAbsolutValue>, IAbsolutValue
    {
        public override void PrintDataToConsole()
        {
            _data = string.Format("Type of plugin is: {0}", this.GetType());
            Console.WriteLine(_data);
        }
        private string _data;
        public override string Data
        {
            get
            {
                _data = string.Format("Type of plugin is: {0}", this.GetType());
                return _data;
            }
        }
        public override IAbsolutValue Plugin
        {
            get
            {
                return this;
            }
        }
        public int AbsoluteValue
        {
            get
            {
                return _AbsoluteValue;
            }

            set
            {
                _AbsoluteValue = value;
            }
        }
        private int _AbsoluteValue = -123456;
    }
}
