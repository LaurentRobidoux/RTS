using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Variables
{
   
    public abstract class RtsVariable : ScriptableObject
    {
        public VariableTag Tag;
    }
    public abstract class RtsVariable<t> : RtsVariable
    {
        
        [SerializeField]
        protected t _value;

        public SpecializedDictionary<int, t> playerMod = new SpecializedDictionary<int, t>();

        public abstract t GetValue(int playerIndex);

        public t Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
   
}

