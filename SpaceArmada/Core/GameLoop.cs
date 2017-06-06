using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SpaceArmada.Gameplay;
using SFML.Graphics;
using SFML.Window;

namespace SpaceArmada.Core
{
    // Dewitters game loop implementation
    class GameLoop
    {

        static RenderTexture renderTexture;

        const int TICKS_PER_SECOND = 60;
        const int SKIP_TICKS = 1000 / TICKS_PER_SECOND;
        const int MAX_FRAMESKIP = 5;

        static int nextGameTick;

        static int previous;

        static Clock tickClock = new Clock();
        static long loops;

        static bool gameIsRunning;

        public static void Init()
        {
            // Do initialization here
            WindowManager.Start();
            Start();
        }
        
        public static void Start()
        {
            VideoMode vm = WindowManager.currentVideoMode;
            renderTexture = new RenderTexture(vm.Width, vm.Height);

            gameIsRunning = true;
            MenuScreen screen = new MenuScreen();
            screen.Start();
            StateManager.Push(screen);
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
            renderTexture.Clear();
            StateManager.Draw(renderTexture);
            renderTexture.Display();

            Sprite drawn = new Sprite(renderTexture.Texture);
            WindowManager.mainWindow.Clear();
            WindowManager.mainWindow.Draw(drawn);
            WindowManager.mainWindow.Display();
        }
    }
}
