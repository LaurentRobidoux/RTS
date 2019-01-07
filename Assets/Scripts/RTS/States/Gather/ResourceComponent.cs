using RTS.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
namespace RTS.States.Gather
{
    public class ResourceComponent : RtsComponent
    {
   
        private void OnEnable()
        {
            Shake();
        }

        public void Update()
        {
          
          
        }
        public void Shake()
        {
            print("shake");
            StartCoroutine(ShakeRoutine());
        }
        private IEnumerator ShakeRoutine()
        {
            for (int index = 0; index < 20; index++)
            {
                print("ShakeRoutine");
                yield return 0;
                transform.Find("Model").localPosition = UnityEngine.Random.insideUnitSphere * 0.1f;
            }
            transform.Find("Model").localPosition = Vector3.zero;
        }
    }
}
