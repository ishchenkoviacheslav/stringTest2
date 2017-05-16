using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class DateTimeData : BaseData<ILocalDateTimeToUTC>, ILocalDateTimeToUTC
    {
        public override void PrintDataToConsole()
        {
            _data = string.Format("Type of plugin is: {0}", this.GetType());
            Console.WriteLine(_data);
        }
        public override ILocalDateTimeToUTC Plugin
        {
            get
            {
                return this;
            }
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

        public DateTime Time
        {
            get
            {
                return _dateTime;
            }

            set
            {
                _dateTime = value;
            }
        }
        private DateTime _dateTime = DateTime.Now;
    }
}
