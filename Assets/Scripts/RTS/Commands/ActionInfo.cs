using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Commands
{
    [CreateAssetMenu]
    public class ActionInfo : ScriptableObject
    {
        public Texture2D Cursor;
        public int Priority;
    }
}
