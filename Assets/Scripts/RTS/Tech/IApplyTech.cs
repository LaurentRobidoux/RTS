using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Tech
{
  
    public interface IApplyTech
    {
        void ApplyTech(int playerIndex,StatIncreaseTech tech);
    }
    [Serializable]
    public class IApplyTechContainer: IUnifiedContainer<IApplyTech> { }
}
