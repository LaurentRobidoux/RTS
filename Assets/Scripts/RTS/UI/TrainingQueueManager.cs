using RTS.Units;
using RTS.Actions.Training;
using RTS.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace RTS.UI
{
    public class TrainingQueueManager : MonoBehaviour
    { 
        public SimpleHealthBar TrainingBar;
        public RawImage Thumbnail;
        public GameObject UnitCell;
        public SelectionSet Selection;
        private TrainComponent trainComponent;
        public GameObject TrainingSlots;
        public void OnSelectionChanged()
        {
            var go = Selection.GetPriorityUnit();
            if (go!=null)
            {
                trainComponent = go.GetComponent<TrainComponent>();
                
               
            }
            else
            {
                trainComponent = null;
                Toggle(false);
            }
          
        }
        public void CancelUnit(int index)
        {
            trainComponent.CancelUnit(index);
        }
        public void Update()
        {
            if (trainComponent != null)
            {

                var first = trainComponent.queue.FirstOrDefault();
                if (first != null)
                {
                    Toggle(true);

                     Thumbnail.texture = first.Thumbnail;
                    if (trainComponent.TrainingTimer!=null)
                    {
                        TrainingBar.UpdateBar(trainComponent.TrainingTimer.Progress, trainComponent.TrainingTimer.Goal);
                    }

                    for (int index = 0; index < TrainingSlots.transform.childCount; index++)
                    {
                        var cell = TrainingSlots.transform.GetChild(index);
                        if (trainComponent.queue.Count>index+1)
                        {
                            
                            var unit = trainComponent.queue[index + 1];
                            cell.gameObject.SetActive(true);
                            cell.GetComponent<RawImage>().texture = unit.Thumbnail;
                        }
                        else
                        {
                            cell.gameObject.SetActive(false);
                        }
                       
                       
                        
                       
                    }

                   
                }
                else
                {
                    Toggle(false);
                }

            }
            else
            {
                Toggle(false);
            }
        }
        public void ClearTrainingSlots()
        {
            foreach (Transform item in TrainingSlots.transform)
            {
                GameObject.Destroy(item.gameObject);
            }
        }
        public void Toggle(bool status)
        {
           
            this.transform.GetChild(0).gameObject.SetActive(status);
        }
     
  
    //    TrainingBar.UpdateBar( current, max );
    }
}
