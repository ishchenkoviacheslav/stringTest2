using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public interface ICollectionPlugins
    {
        List<BasePlugin> ListOfPlugins {get; set; }
    }
}
