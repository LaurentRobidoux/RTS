using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Utils
{
    public class DictoList<tkey, tValue>
    {
        public Dictionary<tkey, List<tValue>> Dicto = new Dictionary<tkey, List<tValue>>();
        /// <summary>
        /// Add value to the list specified by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="unique"></param>
        /// <returns>if the value was added </returns>
        public bool AddToList(tkey key,tValue value,bool unique=true)
        {
            var list = this[key];
            Debug.Log(list);
            if (!list.Contains(value) || !unique)
            {
                list.Add(value);
                return true;
            }
            return false;        
                       
        }
        public bool HasValue(tkey key,tValue value)
        {
            return this[key].Contains(value);
        }
        public List<tValue> this[tkey key]
        {
            get
            {
                List<tValue> val;

                if (!Dicto.TryGetValue(key, out val))
                {
                    val = new List<tValue>();
                    Dicto.Add(key,val );
                }
                return val;
            }
        }
    }
}
