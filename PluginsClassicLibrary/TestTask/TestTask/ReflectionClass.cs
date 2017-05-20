using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace TestTask
{
    static class ReflectionClass
    {
        static  Dictionary<Type, ConstructorInfo> allClassesWithDefaultCtor = new Dictionary<Type, ConstructorInfo>();
        static public async void GetTypesWithDefaultCtor()
        {
            allClassesWithDefaultCtor.Clear();
            await Task.Run(() => 
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        foreach (ConstructorInfo ctor in type.GetConstructors())
                        {
                            if (ctor.GetParameters().Length == 0 && ctor.IsPublic)
                            {
                                allClassesWithDefaultCtor.Add(type, ctor);
                            }
                        }
                    }
                }
            });
        }
        static public object Create(Type type)
        {
            ConstructorInfo ctor = null;
            if(allClassesWithDefaultCtor.TryGetValue(type, out ctor))
            {
                return ctor.Invoke(null);
            }
            return null;
        }

        internal static void AddCtor(Type type, ConstructorInfo ctor)
        {
            allClassesWithDefaultCtor.Add(type, ctor);
        }
    }
}
