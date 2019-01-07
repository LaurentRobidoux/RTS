using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
namespace RTS.States.Move
{
    public class MoveController : SubStateController
    {
        
        private Target Target;
        private NavMeshAgent navMeshAgent;
       
        public override  void Start()
        {
            base.Start();
            navMeshAgent = GetComponent<NavMeshAgent>();   
        }
        public void Move(Target target)
        {
            Move(target,1);
        }
        public void Move(Target target,float stoppingDistance)
        {
           
            navMeshAgent.stoppingDistance = stoppingDistance;
            navMeshAgent.SetDestination(target.Position);
            print(isMoving);
            if (isMoving)
            {
                Target = target;
            } 
           
        }
        public bool isMoving
        {
            get {
               
                    if (!navMeshAgent.pathPending)
                    {

                        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                        {
                            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                            {
                                return false;  
                            }
                        }
                    }
                return true;
                
            }
        }
        private void Update()
        {
            if (Target!=null && !isMoving)
            {
                Target = null;
                print(gameObject.name);
                ObserverCollection.Call(StateEventLibrary.DESTINATION_REACHED);
            }
            UnitComponent.Animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

        }
        public override bool RightClickAction(Target targetPos)
        {

            return targetPos.GameObject == null;
        }
    }
}
