using RTS.Units;
using RTS.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace RTS.UI
{
    public class ArmyPanelManager : MonoBehaviour
    {
        public GameObject CellPrefab;
        public SelectionSet Selection;
        public void ClearPanel()
        {
            foreach (Transform item in transform)
            {
                GameObject.Destroy(item.gameObject);
            }
        }
        public void OnSelectionChanged()
        {
            ClearPanel();
            if (Selection.Items.Count>1)
            {
                var groups = Selection.Items.GroupBy(t => t.GetComponent<UnitComponent>().Model.name);
                foreach (var item in groups)
                {
                    var cell= GameObject.Instantiate(CellPrefab,this.transform);
                    cell.GetComponent<RawImage>().texture = item.First().GetComponent<UnitComponent>().Model.Thumbnail;
                    cell.GetComponentInChildren<Text>().text = item.Count().ToString();
                }
            }
        }
    }
}
