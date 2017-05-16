using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class SomeClass: ICloneable
    {
        public int SomeInt { get; set; }
        public string SomeString { get; set; }

        public object Clone()
        {
            return new SomeClass() { SomeInt = this.SomeInt, SomeString = string.Copy(this.SomeString) };
        }
    }
}
