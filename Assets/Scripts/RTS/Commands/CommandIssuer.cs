
using RTS.Selection;
using RTS.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Commands
{
    public class CommandIssuer : MonoBehaviour
    {
        public SelectionSet selectedUnits;
        public LayerMask layers;
        public void Update()
        {
            if (selectedUnits.Count() > 0)
            {
                Vector3 mouse = Input.mousePosition;
                Ray castPoint = Camera.main.ScreenPointToRay(mouse);
                RaycastHit hit;
                bool result = Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers);
               
                if (result)
                {
                    HandleHover(hit);
                    if (Input.GetMouseButtonDown(1))
                    {
                        HandleMouseClick(hit);
                    }
                }
            }
        }
        private void HandleMouseClick(RaycastHit hit)
        {
            foreach (var item in selectedUnits.Items)
            {
                foreach (var subController in item.GetComponents<SubStateController>())
                {
                    if (!subController.enabled)
                    {
                       
                    }
                    else if (subController.RightClickAction(hit.collider.gameObject))
                    {
                        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            item.GetComponent<StateController>().AddState(subController.CreateState(hit.collider.gameObject));
                        }
                         else
                        {
                            item.GetComponent<StateController>().ChangeState(subController.CreateState(hit.collider.gameObject));
                        }
                        //stop looking in this item
                        break;
                    }
                    else if (subController.RightClickAction(hit.point))
                    {
                    
                        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            item.GetComponent<StateController>().AddState(subController.CreateState(hit.point));
                        }
                        else
                        {
                            item.GetComponent<StateController>().ChangeState(subController.CreateState(hit.point));
                        }
                      
                        break;
                    }
                }
            }
        }
        private bool HandleCursor(RaycastHit hit)
        {
            foreach (var item in selectedUnits.Items)
            {

                foreach (var subController in item.GetComponents<SubStateController>())
                {
                    
                    if (subController.HoverTarget(hit.collider.gameObject))
                    {
                        Cursor.SetCursor(subController.Info.Cursor, Vector2.zero, CursorMode.Auto);
                        //stop looking
                        return true;
                    }
                }
            }
            return false;
        }

        private void HandleHover(RaycastHit hit)
        {          
            if (!HandleCursor(hit))
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
