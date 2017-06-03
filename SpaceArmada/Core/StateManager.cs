using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArmada.Core
{
    class StateManager
    {
        static Stack<Screen> screens = new Stack<Screen>();
        public void Push(Screen screen)
        {
            screens.Push(screen);
        }

        public Screen Pop()
        {
            return screens.Pop();
        }
    }
}
