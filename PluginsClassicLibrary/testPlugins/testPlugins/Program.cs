using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugins;
namespace testPlugins
{
    class ImplementMultiply : IMyltiply
    {
        private int _intMyltiply = 34;
        public int IntDataForMyltipy
        {
            get
            {
                return _intMyltiply;
            }

            set
            {
                _intMyltiply = value;
            }
        }
    }
    class ImplementAbsolutValue : IAbsolutValue
    {
        public int AbsoluteValue
        {
            get;
            set;
        } = -12;
    }
    class ImplementDataToUTC : ILocalDateTimeToUTC
    {
        private DateTime _dateTime;
        public DateTime Time
        {
            get
            {
                return DateTime.Now;
            }

            set
            {
                _dateTime = value;
            }
        }
    }
    class ImplementPluginsCollection : ICollectionPlugins
    {
        private List<BasePlugin> _listPlugins;
        public List<BasePlugin> ListOfPlugins
        {
            get
            {
                return _listPlugins;
            }

            set
            {
                _listPlugins = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PluginPluginable<IMyltiply> itself = new PluginPluginable<IMyltiply>();
            itself.IntDataForMyltipy = -5;
            IMyltiply resultMyltiply = itself.MyltiplyNumber(new ImplementMultiply());
            Console.WriteLine(resultMyltiply.IntDataForMyltipy);

            PluginInt<IAbsolutValue> IntAbsVal = new PluginInt<IAbsolutValue>();
            IAbsolutValue resultAbsolutVal = IntAbsVal.AbsoluteValue(new ImplementAbsolutValue());
            Console.WriteLine(resultAbsolutVal.AbsoluteValue);

            PluginDateTimeToUTC<ILocalDateTimeToUTC> DataToUTC = new PluginDateTimeToUTC<ILocalDateTimeToUTC>();
            ILocalDateTimeToUTC resultDataToUTC = DataToUTC.TimeToUTC(new ImplementDataToUTC());
            Console.WriteLine(resultDataToUTC.Time);

            PluginCollection<ICollectionPlugins> pluginsCollection = new PluginCollection<ICollectionPlugins>();
            ImplementPluginsCollection ImplemPlugColl = new ImplementPluginsCollection();
            ImplemPlugColl.ListOfPlugins = new List<BasePlugin>()
            {
                new PluginInt<IAbsolutValue>(), new PluginDateTimeToUTC<ILocalDateTimeToUTC>()
            };
            pluginsCollection.dateTimeData = new DateTimeData();
            pluginsCollection.integerData = new IntegerData();
            pluginsCollection.ApplyAllPlugins(ImplemPlugColl);
            
        }
    }
}
