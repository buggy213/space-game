using SFML.Graphics;
using SpaceArmada.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArmada.Gameplay
{
    class MenuScreen : Screen
    {

        public override void Start()
        {
            base.Start();
            background = new Texture("Assets/SplashScreen.png");
            backgroundSprite = new Sprite(background);

            backgroundSprite.Position = WindowManager.Center(background.Size);

            float xScaleFactor = WindowManager.currentVideoMode.Width / background.Size.X;
            float yScaleFactor = WindowManager.currentVideoMode.Height / background.Size.Y;
            backgroundSprite.Scale = backgroundSprite.Scale * (xScaleFactor > yScaleFactor ? yScaleFactor : xScaleFactor);
        }

        public void KeyPressedHandler()
        {

        }
    }
}
