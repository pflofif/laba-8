using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Properties
{
    class TaskFor10Lab
    {
        private ArrayList viewerList = new ArrayList();
        struct ArrayAsociat
        {
            public int key;
            public object value;
            public override string ToString()
            {
                return value.ToString();
            }
            public override int GetHashCode()
            {
                return key;
            }
        }
        public object this[int index]
        {
            get
            {
                foreach (var VARIABLE in viewerList)
                {
                    if (VARIABLE.GetHashCode() == index)
                    { 
                        return VARIABLE.ToString();
                    }
                }
                Console.WriteLine("NO INDEX");
                return string.Empty;
            }
            set
            {
                var keyValue = new ArrayAsociat() {key = index, value = value};
                viewerList.Add(keyValue);
            }
        }

    }
}
