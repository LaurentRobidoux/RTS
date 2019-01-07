using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Variables
{
    /// <summary>
    /// Dictionary that set the value if not present
    /// </summary>
    /// <typeparam name="tkey"></typeparam>
    /// <typeparam name="tValue"></typeparam>
    public class SpecializedDictionary<tkey,tValue>
    {
        public Dictionary<tkey, tValue> Dicto = new Dictionary<tkey, tValue>();
        public  tValue this[tkey key]
        {
            get
            {
                tValue val;
                
                if (!Dicto.TryGetValue(key, out val))
                {
                    Dicto.Add(key, default(tValue));
                }
                return val;
            }
        }
    }
}
