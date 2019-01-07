using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Fog_of_war.Scripts
{
    public class LineOfSight : MonoBehaviour
    {
        public GameObject Aperture;
        [Range(0,1000)]
        public float radius = 3;
        public void OnValidate()
        {
            if (Aperture!=null)
            {
               Vector3 vec= Aperture.transform.localScale;
                vec.x = radius;
                vec.z = radius;
                Aperture.transform.localScale = vec;
            }
        }
        private void Reset()
        {
            if (Aperture==null)
            {
               Aperture= transform.Find("Aperture").gameObject;
            }
        }

    }
}
