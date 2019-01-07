using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Variables
{
    [Serializable]
    public class VariableCollection : DistinctList<RtsVariable>
    {
        public t FindByTag<t>(VariableTag tag) where t : RtsVariable
        {
            return (t)Collections.FirstOrDefault(p => p.Tag.Equals(tag));
        }
    }
}
