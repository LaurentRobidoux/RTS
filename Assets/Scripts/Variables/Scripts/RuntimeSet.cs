using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Variables
{

    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [System.NonSerialized]
        public List<T> Items = new List<T>();

        public void Add(T thing)
        {
            if (!Items.Contains(thing))
                Items.Add(thing);
        }
        public int Count()
        {
            return Items.Count;
        }
        public void Remove(T thing)
        {
            if (Items.Contains(thing))
                Items.Remove(thing);
        }
    }
}
