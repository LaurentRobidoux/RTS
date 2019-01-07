using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Variables;
namespace RTS.Units
{
    [RequireComponent(typeof(UnitComponent))]
   public abstract class RtsComponent : MonoBehaviour
    {
        private UnitComponent _unitComponent;
        public UnitComponent UnitComponent { get
            {
                if (_unitComponent==null)
                {
                    _unitComponent= GetComponent<UnitComponent>();
                }
                return _unitComponent;
            }
        }
        public int PlayerIndex { get { return UnitComponent.PlayerIndex; } }
        public virtual void Start()
        {  
            foreach (var item in GetType().GetFields().Where(t=> typeof(RtsReference).IsAssignableFrom(t.FieldType)))
            {
                RtsReference refe=(RtsReference) item.GetValue(this);
                refe.playerIndex = PlayerIndex;
       
            }
        }
    }
}
