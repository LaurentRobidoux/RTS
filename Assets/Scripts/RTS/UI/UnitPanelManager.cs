using RTS.Units;
using RTS.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using RTS.States.Attack;

namespace RTS.UI
{
    public class UnitPanelManager : MonoBehaviour
    {
        public RawImage Thumbnail;
        public Text AttackText;
        public SelectionSet Selection;
        public Text UnitLabelName;
        public SimpleHealthBar healthBar;
        SelectionComponent CurrentUnit;
        
        public void OnSelectionChanged()
        {
            RemoveListeners();
           CurrentUnit= Selection.GetPriorityUnit();
            if (CurrentUnit !=null)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                var attackController = CurrentUnit.GetComponent<AttackController>();
                if (attackController==null)
                {
                    AttackText.transform.parent.gameObject.SetActive(false);
                }
                else
                {
                    AttackText.transform.parent.gameObject.SetActive(true);
                    AttackText.text = CurrentUnit.GetEnabledComponent<AttackController>().AttackPower.ToString();
                }

                
                UnitLabelName.text = CurrentUnit.GetComponent<UnitComponent>().Model.name;
                Thumbnail.texture = CurrentUnit.GetComponent<UnitComponent>().Model.Thumbnail;
              
                
                var des = CurrentUnit.GetComponent<DestructableComponent>();
                if (des!=null)
                {
                    CurrentUnit.GetComponent<DestructableComponent>().OnDamageTaken.AddListener(SelectedOnDamageTaken);
                    SelectedOnDamageTaken();
                }
              
               
            }
            else
            {
                //nothing selected
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        void RemoveListeners()
        {
            if (CurrentUnit!=null)
            {
                CurrentUnit.GetComponent<DestructableComponent>().OnDamageTaken.RemoveListener(SelectedOnDamageTaken);
            }
           
        }
        void SelectedOnDamageTaken()
        {
            var des = CurrentUnit.GetComponent<DestructableComponent>();
            healthBar.UpdateBar(des.CurrentHp, des.MaxHealth);
        }


    }
}
