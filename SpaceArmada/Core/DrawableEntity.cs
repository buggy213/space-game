using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace SpaceArmada.Core
{
    public class DrawableEntity : Entity, IDraw
    {
        public Sprite sprite;
        public Texture texture;

        public DrawableEntity(DrawableEntity other) : base(other)
        {
            this.sprite = other.sprite;
            this.texture = other.texture;
        }

        public virtual void Draw(RenderTexture rt)
        {
            rt.Draw(sprite);
        }
    }
}
