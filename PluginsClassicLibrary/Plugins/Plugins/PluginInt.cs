using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class PluginInt<T> : BasePlugin where T : IAbsolutValue
    {
        public T AbsoluteValue(T value)
        {
                value.AbsoluteValue = Math.Abs(value.AbsoluteValue);
            return value;
        }
    }
}
