using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utils
{
    [CreateAssetMenu]
    public class RaycastHelper : ScriptableObject
    {
        static RaycastHelper _instance = null;
        public LayerMask IgnoreLayer;
        public static RaycastHelper Instance
        {
            get
            {
                if (!_instance)
                    _instance = Resources.FindObjectsOfTypeAll<RaycastHelper>().FirstOrDefault();
                return _instance;
            }
        }
 
        public RaycastHit MouseToGame()
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            Physics.Raycast(castPoint, out hit, Mathf.Infinity, ~0-IgnoreLayer);
            return hit;
           
        }
    }
}
