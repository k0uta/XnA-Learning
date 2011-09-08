using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstSideScroller
{
    class Entity
    {

        //The position Vector
        protected Vector2 position;

        //The entity texture
        protected Texture2D texture;

        //The source rectangle, pointing where (X and Y) and the size of the entity
        protected Rectangle source;

        //The constructor
        public Entity(Vector2 pos, Texture2D tex)
        {
            //Set the position and the texture
            position = pos;
            texture = tex;

            //Intializes the source rectangle to avoid errors
            source = new Rectangle(0, 0, tex.Width, tex.Height);

        }

        //The draw method
        public virtual void Draw()
        {

            //Draw the entity using the parameters
            SideScroller.spriteBatch.Draw(texture, position, source, Color.White);

        }

        //The update method
        public virtual void Update(GameTime gTime)
        {

        }
    }
}
