using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    abstract public class BaseData<T>
    {
        abstract public T Plugin { get; }
        abstract public void PrintDataToConsole();
        //data property
        abstract public string Data { get; }
        public Type PluginType
        {
            get
            {
                return typeof(T);
            }
        }
    }
}
