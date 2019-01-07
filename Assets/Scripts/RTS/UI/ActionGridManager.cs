using RTS.Actions;
using RTS.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.UI
{
    public class ActionGridManager : MonoBehaviour
    {
        private static ActionGridManager _instance;
        public static ActionGridManager Instance { get { return _instance; } }
        public SelectionSet Selection;
        public GameObject CellPrefab;
        public void OnCellClicked(ActionGridElement actionElement)
        {
            //find all with actionGridComponents within selected
            List<ActionGridComponent> list=  Selection.GetComponents<ActionGridComponent>();
            foreach (var go in list)
            {
                var act= go.list.FirstOrDefault(t => t == actionElement);
                if (act!=null)
                {
                    //Execute action if available
                    act.Execute(go.gameObject);
                }
            }
        }
        public void Awake()
        {
            _instance = this;
        }
        public void OnSelectionChanged()
        {
            ClearPanel();
            GenerateGrid();
        }
        public void GenerateGrid()
        {
            try
            {
                ActionGridComponent comp = Selection.GetPriorityUnit().GetComponent<ActionGridComponent>();
                if (comp != null)
                {
                    foreach (var item in comp.list)
                    {
                        var ob = GameObject.Instantiate(CellPrefab, this.transform);
                        ob.GetComponent<ActionCellComponent>().Action = item;
                    }
                }
            }
            catch (Exception)
            {

            }
         
           
        }
        public void ClearPanel()
        {
            foreach (Transform item in transform)
            {
                GameObject.Destroy(item.gameObject);
            }
        }

    }
}
