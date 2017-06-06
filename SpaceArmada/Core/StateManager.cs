using SFML.Graphics;
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
        public static void Push(Screen screen)
        {
            screens.Push(screen);
        }

        public static Screen Pop()
        {
            return screens.Pop();
        }

        public static void Draw(RenderTexture rt)
        {
            List<Screen> screensList = screens.ToList();
            int nonBlockedScreens = 0;
            for (int i = 0; i < screens.Count; i++)
            {
                if (screensList[i].blocking)
                {
                    nonBlockedScreens = i;
                    break;
                }
            }
            for (int j = nonBlockedScreens; j > 0; j--)
            {
                screensList[j].Draw(rt);
            }
        }

    }
}
