using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DSotB
{
    public class Entity
    {

        protected Vector2 position;
        protected Texture2D texture;
        protected Rectangle source;
        protected Rectangle hitBox;

        public virtual void Draw(GameTime gameTime)
        {

            DSotB.spriteBatch.Draw(texture, position, source, Color.White);

        }

        public virtual void Update(GameTime gameTime)
        {



        }

        public bool CheckCollision(Entity targetEnt)
        {

            return hitBox.Intersects(targetEnt.hitBox);

        }

    }
}
