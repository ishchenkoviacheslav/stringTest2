using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class PluginCollection<T> : BasePlugin where T : ICollectionPlugins
    {
        //заглушки для поступления данных
        public ILocalDateTimeToUTC dateTimeData { get; set; }
        public IAbsolutValue integerData { get; set; }


        public T ApplyAllPlugins(T collection)
        {
            foreach (BasePlugin plugin in collection.ListOfPlugins)
            {
                if (plugin is PluginDateTimeToUTC<ILocalDateTimeToUTC>)
                {
                    PluginDateTimeToUTC<ILocalDateTimeToUTC> TimePlugin = (PluginDateTimeToUTC<ILocalDateTimeToUTC>)plugin;
                    ((DateTimeData)dateTimeData).PrintDataToConsole();
                    //в реальных условиях данные должны поступать из вне
                    TimePlugin.TimeToUTC(dateTimeData);
                }
                if (plugin is PluginInt<IAbsolutValue>)
                {
                    PluginInt<IAbsolutValue> IntPlugin = (PluginInt<IAbsolutValue>)plugin;
                    ((IntegerData)integerData).PrintDataToConsole();
                    //в реальных условиях данные должны поступать из вне
                    IntPlugin.AbsoluteValue(integerData);
                }
            }
            //Return only because of the need for a signature
            return collection;
        }
    }
}
