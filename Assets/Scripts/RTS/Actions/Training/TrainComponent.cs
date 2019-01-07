using RTS.Units;
using Assets.Utils;


using RTS.Selection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils;
using RTS.States.Move;
using RTS.States;

namespace RTS.Actions.Training
{
    public class TrainComponent : RtsComponent
    {
        public List<TrainModule> queue;
        public Timer TrainingTimer;
        public GameObject RallyFlag;
        public bool RallyPointSet=false;
        public void Update()
        {
            if (queue.Count > 0)
            {
                if (TrainingTimer == null)
                {
                    var first = queue.FirstOrDefault();
                    TrainingTimer = new Timer(first.Time);
                    TrainingTimer.OnTimerComplete += (sender, e) => TrainingTimer_OnTimerComplete(sender, e, first);
                }
                TrainingTimer.Update();

            }

            //Rally point
            if (Input.GetMouseButtonDown(1) && GetComponent<SelectionComponent>().isSelected)
            {
               var hit= RaycastHelper.Instance.MouseToGame();
                if (hit.collider.gameObject==gameObject)
                {
                    RemoveRallyPoint();
                }else
                {
                    MoveRallyPoint(hit.point);
                }
                
            }
        }
        public void MoveRallyPoint(Vector3 position)
        {
            RallyFlag.SetActive(true);
            RallyFlag.GetComponent<AudioSource>().Play();
           
            RallyFlag.transform.position = position;
            RallyPointSet = true;
        }
        public void RemoveRallyPoint()
        {
            RallyPointSet = false;
            RallyFlag.SetActive(false);
        }

        public void CancelUnit(int index)
        {
            if (index==0)
            {
                TrainingTimer = null;
               
            }
            queue.RemoveAt(index);
        }
        public void OnSelected()
        {
            RallyFlag.SetActive(RallyPointSet);
        }
        public void OnDeselected()
        {
            RallyFlag.SetActive(false);
        }
        private void TrainingTimer_OnTimerComplete(object sender, EventArgs e, TrainModule module)
        {
            module.Train(this);
            queue.RemoveAt(0);
            TrainingTimer = null;
        }
        public void SpawnUnit(GameObject prefab)
        {
            var unit = GameObject.Instantiate(prefab, this.transform.position, this.transform.localRotation, this.transform.parent);
            if (RallyPointSet)
            {
                var moveComponent = unit.GetComponent<MoveController>();
                unit.GetComponent<StateController>().ChangeState(moveComponent.CreateState(RallyFlag.transform.position));
            }

          
        }

        public void Train(TrainModule unitToTrain)
        {
          
            queue.Add(unitToTrain);   
        }
    }
}
