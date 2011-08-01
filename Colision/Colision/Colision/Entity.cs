﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Colision
{
    class Entity
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

    }
}
