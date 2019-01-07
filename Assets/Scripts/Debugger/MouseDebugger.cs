using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Debugger
{
    public class MouseDebugger : MonoBehaviour
    {
      
        public void OnGUI()
        {
            //Todo : move to side if close to border
            Vector2 pos = Input.mousePosition;
            pos.y = Screen.height - pos.y;
            pos.x += 10;
            Rect rect = new Rect(pos, new Vector2(80, 30));
            
            ShapeDrawer.DrawScreenRect(rect, new Color(0.5f, 0.5f, 0.5f, 0.5f));
            Vector2 vec = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GUI.Label(rect,vec.ToString());
            
        }
    }
}
