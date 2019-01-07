using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class DistinctList<t>
    {
        [SerializeField]
        public List<t> _collections;
        public List<t> Collections
        {
            get
            {
                if (_collections==null)
                {
                    _collections = new List<t>();
                }
                return _collections;
            }
        }
        public void Add(t item)
        {
          
           t o= Collections.Find(t => t.Equals(item));
            if (o==null)
            {
                Collections.Add(item);
            }
        }
    }
}
