using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArmada.Core
{
    class WindowManager
    {
        public static RenderWindow mainWindow;

        public static VideoMode currentVideoMode;
        
        public static void Start()
        {
            currentVideoMode = VideoMode.FullscreenModes[0];
            mainWindow = new RenderWindow(currentVideoMode, "Space Armada", Styles.Fullscreen);
            mainWindow.Closed += Closed;
        }

        public static Vector2f Position(float x, float y, Vector2u size)
        {
            return new Vector2f((currentVideoMode.Width * x - size.X / 2), (currentVideoMode.Height * y - size.Y / 2));
        }

        public static Vector2f Center(Vector2u size)
        {
            return Position(0.5f, 0.5f, size);
        }

        private static void Closed(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
    }
}
