using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;

namespace SpaceArmada.Core
{
    // Dewitters game loop implementation
    class GameLoop
    {
        const int TICKS_PER_SECOND = 60;
        const int SKIP_TICKS = 1000 / TICKS_PER_SECOND;
        const int MAX_FRAMESKIP = 5;

        static int nextGameTick;

        static int previous;

        static Clock tickClock;
        static long loops;

        static bool gameIsRunning;

        public static void Init()
        {
            // Do initialization here

            Start();
        }
        
        public static void Start()
        {
            gameIsRunning = true;
            Loop();
        }

        public static void Loop()
        {
            while (gameIsRunning)
            {
                loops = 0;
                while (tickClock.ElapsedTime.AsMilliseconds() > nextGameTick && loops < MAX_FRAMESKIP)
                {
                    int delta = tickClock.ElapsedTime.AsMilliseconds() - previous;
                    previous = tickClock.ElapsedTime.AsMilliseconds();
                    Tick(delta);

                    nextGameTick += SKIP_TICKS;
                    loops++;
                }

                Draw();
            }
        }

        public static void Exit()
        {
            // Do cleanup stuff here
        }

        static void Tick(int deltaTime)
        {
            foreach (ITick tickable in TickManager.Tickables)
            {
                tickable.Tick(deltaTime);
            }
        }

        static void Draw()
        {
            
        }
    }
}
