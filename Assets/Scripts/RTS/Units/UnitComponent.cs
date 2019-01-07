using Assets.Fog_of_war.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Units
{
    [ExecuteInEditMode]
    public class UnitComponent : MonoBehaviour
    {
        PlayerManager playerManager;
        public UnitModel Model;
        public int PlayerIndex
        {
            get
            {
                if (playerManager==null)
                {
                    playerManager = transform.parent.GetComponent<PlayerManager>();
                }
                return playerManager.PlayerIndex;
            }
        }
        private void OnTransformParentChanged()
        {
            playerManager = transform.parent.GetComponent<PlayerManager>();
        }
        public Animator Animator
        {
            get
            {
                return GetComponentInChildren<Animator>();
            }
        }
    }
}
