using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArmada.Core
{
    public class Screen : ITick, IDraw
    {
        public List<Entity> entities = new List<Entity>();

        protected Texture background;
        protected Sprite backgroundSprite;


        // Does this screen block the screens behind it from rendering? For most things this should probably be yes. 
        public bool blocking = true;

        public virtual void Start()
        {
            StateManager.Push(this);
        }

        protected void Exit()
        {
            StateManager.Pop();
        }

        public virtual void Tick(int deltaTime)
        {
            
        }

        public virtual void Draw(RenderTexture rt)
        {
            if (backgroundSprite != null)
            {
                rt.Draw(backgroundSprite);
            }

            foreach (Entity entity in entities)
            {
                if (entity is DrawableEntity)
                {
                    ((DrawableEntity)entity).Draw(rt);
                }
            }
        }
    }
}
