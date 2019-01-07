using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Variables
{
    /// <summary>
    /// This class exist only for the editor
    /// </summary>
    public abstract class RtsReference
    {
        /// <summary>
        /// The playerIndex to refer to get the upgraded value
        /// </summary>
        public int playerIndex { get; set; }
    }
    public abstract class RtsReference<t,s> : RtsReference where t : RtsVariable<s>
    {

        public bool UseConstant = true;
        public s ConstantValue;
        public t Variable;

        public RtsReference()
        { }

        public RtsReference(s value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public s Value
        {
            get { return UseConstant ? ConstantValue : Variable.GetValue(playerIndex); }
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    [Serializable]
    public class FloatReference : RtsReference<FloatVariable,float>
    {
        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
    [Serializable]
    public class IntReference : RtsReference<IntVariable, int>
    {
        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }

}