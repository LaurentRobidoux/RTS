using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variables;
using UnityEngine;
namespace RTS.Selection
{
    [CreateAssetMenu(menuName ="RuntimeSet/Selection")]
    public class SelectionSet : RuntimeSet<SelectionComponent>
    {
        public SelectionComponent GetPriorityUnit()
        {
            return Items.FirstOrDefault();
        }
        public List<t> GetComponents<t>()
        {
            List<t> elements = new List<t>();
            foreach (var item in Items)
            {
                t comp = item.GetComponent<t>();
                if (comp!=null)
                {
                    elements.Add(comp);
                }
            }
            return elements;
        }
    }
}
