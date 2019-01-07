using RTS.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RTS.UI
{
    public class ActionCellComponent : MonoBehaviour, IPointerUpHandler
    {
        public ActionGridElement Action;
        private void Start()
        {
            GetComponent<RawImage>().texture = Action.Icon;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            //must call back the armypanel manager
            //call event
            //Action.OnClick();
            ActionGridManager.Instance.OnCellClicked(Action);
        }
    }
}