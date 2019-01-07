using Assets.Scripts.Utils;
using GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace RTS.Selection
{
    /// <summary>
    /// Class in charge of the mouse and selection
    /// </summary>
    public class SelectionManager : MonoBehaviour
    {
        bool isSelecting = false;
        /// <summary>
        /// Position of the mouse when mouseDown began
        /// </summary>
        Vector3 mousePosition1;
        public RaycastHelper RaycastHelper;
        /// <summary>
        /// Required distance to enable the multi select
        /// </summary>
        [Range(1, 10)]
        public float range = 1.0f;
        public LayerMask hitLayers;
        public static SelectionManager Instance { get; private set; }
        public GraphicRaycaster graphicRay;
        private void Awake()
        {
            Instance = this;
        }
        void OnGUI()
        {

            if (isSelecting)
            {

                var rect = ShapeDrawer.GetScreenRect(mousePosition1, Input.mousePosition);
                ShapeDrawer.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));

                SelectedUnits = GetUnitsInBound(mousePosition1, Input.mousePosition);

                OnSelectionChangeHandler.Raise();

            }
        }
        void Update()
        {
            //Avoid the UI

            //Set the Pointer Event Position to that of the mouse position
            List<RaycastResult> results = new List<RaycastResult>();
            PointerEventData ptr = new PointerEventData(EventSystem.current);
                ptr.position = Input.mousePosition;
            graphicRay.Raycast(ptr,results);
            LayerMask uiLayer = LayerMask.NameToLayer("UIPanel");
            if (results.Count>0)
            {
                return;
            }
         
                if (Input.GetMouseButtonDown(0))
            {
                mousePosition1 = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                isSelecting = Math.Abs((mousePosition1 - Input.mousePosition).magnitude) >= range;
            }



            if (Input.GetMouseButtonUp(0))
            {
                //if we are not selecting, then we select the single unit under the mouse no matter what faction it is
                if (!isSelecting)
                {
                    Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
                    {
                        var obj = hit.collider.GetComponent<SelectionComponent>();
                        if (obj != null)
                        {
                            Clear();
                            Add(obj);
                        }

                    }
                    else
                    {
                        Clear();
                    }
                }
                isSelecting = false;
            }


        }

        public Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2)
        {
            var v1 = Camera.main.ScreenToViewportPoint(screenPosition1);
            var v2 = Camera.main.ScreenToViewportPoint(screenPosition2);
            var min = Vector3.Min(v1, v2);
            var max = Vector3.Max(v1, v2);
            min.z = camera.nearClipPlane;
            max.z = camera.farClipPlane;

            var bounds = new Bounds();
            bounds.SetMinMax(min, max);
            return bounds;
        }
        /// <summary>
        /// Return the player units
        /// </summary>
        /// <returns></returns>
        public SelectionComponent[] GetMyUnits()
        {

            return this.transform.GetComponentsInChildren<SelectionComponent>();

        }


        public List<SelectionComponent> GetUnitsInBound(Vector3 pos1, Vector3 pos2)
        {
            var camera = Camera.main;
            var viewportBounds = GetViewportBounds(camera, pos1, pos2);
            var list = GetMyUnits();
            List<SelectionComponent> selected = new List<SelectionComponent>();
            foreach (SelectionComponent item in list)
            {
                if (viewportBounds.Contains(camera.WorldToViewportPoint(item.transform.position)))
                {
                    selected.Add(item);
                }
            }
            return selected;
        }
       public SelectionSet _selectedUnits;
        /// <summary>
        /// Todo : add observer
        /// </summary>
        public List<SelectionComponent> SelectedUnits
        {
            get
            { return _selectedUnits.Items; }
            set
            {
                SetSelection(_selectedUnits.Items, false);
                _selectedUnits.Items = value;
                SetSelection(_selectedUnits.Items, true);
            }
        }

        public GameEvent OnSelectionChangeHandler;
        public void Add(SelectionComponent go)
        {
            SelectedUnits.Add(go);
            go.Select();


            OnSelectionChangeHandler.Raise();
            
            // go.GetComponent<GameObject>().Select();
        }
        public void Clear()
        {
            SetSelection(SelectedUnits, false);
            SelectedUnits.Clear();
            OnSelectionChangeHandler.Raise();
            
        }

        public void SetSelection(IEnumerable<SelectionComponent> units, bool active)
        {
            if (units != null)
            {
                foreach (var item in units)
                {
                    item.Select(active);
                }
            }
        }

        public SelectionComponent GetPriorityUnit()
        {
            return SelectedUnits.FirstOrDefault();
        }

    }

}
