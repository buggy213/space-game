using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArmada.Core
{
    public class Entity : ITick
    {
        Screen parent;

        public Entity()
        {

        }

        public Entity(Entity other)
        {
            this.parent = other.parent;
        }

        public virtual void Start(Screen screen)
        {
            screen.entities.Add(this);
            parent = screen;
        }

        public virtual void Destroy()
        {
            parent.entities.Remove(this);
        }

        public virtual void Tick(int deltaTime)
        {
            
        }
    }
}
