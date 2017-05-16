using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class PluginDateTimeToUTC<T> : BasePlugin where T : ILocalDateTimeToUTC
    {
        public T TimeToUTC(T time)
        {
            time.Time = time.Time.ToUniversalTime();
            return time;
        }
    }
}
