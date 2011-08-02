using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Colision
{
    public abstract class Entity
    {

        //Entity position x and y
        protected Vector2 position;

        //Entity texture
        protected Texture2D texture;

        //The vars above and the draw method are the ones that I found useful now, but I want to change to a better way in the future

        //The Rectangle that will define what part of the texture will be draw
        protected Rectangle source;

        //This vector defines the size of the Entity, use it to split the texture
        protected Vector2 size;

        //This vector defines the frame of the splitted texture that's going to be draw
        protected Vector2 frame;

        //The Draw function, I made it virtual cause I want to have the option to override this function
        public virtual void Draw(SpriteBatch sBatch)
        {

            //Defines the 'Rectangle' that's going to be draw, as I said, I want to change this method in the future
            source = new Rectangle((texture.Width / (int)size.X) * (int)frame.X, (texture.Height / (int)size.Y) * (int)frame.Y, (texture.Width / (int)size.X), (texture.Height / (int)size.Y));

            //Calls the draw method of the SpriteBatch
            sBatch.Draw(texture, position, source, Color.White);

        }

        //The Update function, it's blank but I don't want to call different Updates from each class that uses Entity as base
        public virtual void Update(GameTime gTime)
        {

        }

        //The constructor of the class, takes the position texture and size
        public Entity(Vector2 pos, Texture2D tex, Vector2 siz)
        {

            //Defines the position, texture and size of the Entity
            position = pos;
            texture = tex;
            size = siz;

            //The frame by default will be 0,0
            frame = Vector2.Zero;

        }

    }
}
