using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RTS.UI
{

    public class MinimapManager : MonoBehaviour, IPointerClickHandler
    {
        public Camera Camera;
        public Collider Map;
        public RectTransform RectTransform
        {
            get { return this.GetComponent<RectTransform>(); }
                }
        public void OnPointerClick(PointerEventData eventData)
        {
         
            var t = Test();
            print("Test : "+t);
            Camera.transform.position = t;
         

        }
        public Vector3 Test()
        {
            float MapWidth = Map.bounds.size.x;
            float MapHeight = Map.bounds.size.y;
            var miniMapRect = GetComponent<RectTransform>().rect;
            var screenRect = new Rect(
                transform.position.x,
                transform.position.y,
                miniMapRect.width, 50);
            print("screeeeeen : " + screenRect);
            var mousePos = Input.mousePosition;
            mousePos.y -= screenRect.y;
            mousePos.x -= screenRect.x;
            print("mousepos : " + mousePos.ToString());
            return new Vector3(
                mousePos.x * (MapWidth / screenRect.width),
                Camera.transform.position.y,
                mousePos.y * (MapHeight / screenRect.height));
           /* var camPos = 
                Camera.main.transform.position.z);*/
        }
        public Vector3 GetMinimapToWorldPosition(Vector2 position)
        {
            //https://www.reddit.com/r/Unity3D/comments/48ao2u/getting_world_position_from_clickable_minimap_tips/
            Rect rect = RectTransform.rect;
            Vector3 transpos = transform.position;
           
    //   Rect rectangle= 
                  print("sizeDelta : " + new Vector2(RectTransform.sizeDelta.x, RectTransform.sizeDelta.y));
            print("transform : " + transform.position.ToString());
            print("Rect : " + rect.ToString());
            print("Screen : " + new Vector2(Screen.width,Screen.height));
            print("Map : " + Map.bounds.size);
            // print("screenRect : " + screenRect.ToString());
            // rect.y = Screen.height - rect.y;
            //x = min x, y = z min, z = x max, w = z max
            var mousePos = position;
            mousePos.y = Screen.height - mousePos.y;
          //  mousePos.x -= screenRect.x;
           // Vector4 camMinMax=new Vector4(0.0f,0.0f,Map.bounds.size.x,Map.bounds.size.z);
            var camPos = new Vector3(
          mousePos.x * (Map.bounds.size.x / rect.width),
          Camera.transform.position.y,
          mousePos.y * (Map.bounds.size.y / rect.height)
          );
            return camPos;
           
        }
    }
}
