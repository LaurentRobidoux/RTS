using RTS.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Actions
{
    public abstract class ActionGridElement : ScriptableObject
    {
        public Texture2D Icon;
      
            
        
        public abstract void Execute(GameObject source);


    }
}
