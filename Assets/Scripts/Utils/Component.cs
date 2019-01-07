using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
   public static class GameObjectExtension
    {
        public static t GetEnabledComponent<t>(this Component comp) where t : MonoBehaviour
        {
            return comp.GetComponents<t>().FirstOrDefault(p => p.enabled);
        }
        public static t GetEnabledComponent<t>(this GameObject comp) where t : MonoBehaviour
        {
            return comp.GetComponents<t>().FirstOrDefault(p => p.enabled);
        }
    }
}
