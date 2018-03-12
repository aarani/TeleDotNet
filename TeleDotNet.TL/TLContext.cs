using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TeleDotNet.TL;
namespace TeleDotNet.TL
{
    public static class TLContext
    {
        private static Dictionary<int, Type> Types;

        public static void Init()
        {
            Types = new Dictionary<int, Type>();
            Types = (from t in Assembly.GetExecutingAssembly().GetTypes()
                     where t.IsClass && t.Namespace.StartsWith("TeleDotNet.TL")
                     where t.IsSubclassOf(typeof(TLObject))
                     where t.GetCustomAttribute(typeof(TLObjectAttribute)) != null
                     select t).ToDictionary(x => ((TLObjectAttribute)x.GetCustomAttribute(typeof(TLObjectAttribute))).Constructor, x => x);
            Types.Add(481674261, typeof(TLVector<>));
        }
        public static Type getType(int Constructor)
        {
            return Types[Constructor];
        }
    }
}
