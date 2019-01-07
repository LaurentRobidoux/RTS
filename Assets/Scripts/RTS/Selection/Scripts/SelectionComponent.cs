using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Selection
{
    public class SelectionComponent : MonoBehaviour
    {
        public GameObject Projector;
        public bool isSelected = false;
        public void Select()
        {
            Select(true);
        }
        public void Select(bool selected)
        {
            isSelected = selected;
            Projector.SetActive(selected);
            if (selected)
            {
                SendMessage("OnSelected",SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                SendMessage("OnDeselected", SendMessageOptions.DontRequireReceiver);
            }
            
        }
        public void Deselect()
        {
            Select(false);
        }
        private void Reset()
        {
            if (Projector == null)
            {
                Projector = transform.Find("Projector").gameObject;
            }
        }
    }
}
