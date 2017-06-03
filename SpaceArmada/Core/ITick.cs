using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArmada.Core
{
    public interface ITick
    {
        void Tick (int deltaTime);
    }
}
