using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstSideScroller
{
    class Player:Entity
    {

        //Some player parameters
        protected int frameNumber;
        protected float frameSize;

        //The player constructor
        public Player(Vector2 pos, Texture2D tex, int numberFrame)
            : base(pos, tex)
        {

            //Set the number o frames
            frameNumber = numberFrame;

            //Calculates the frame size according to the number o frames
            frameSize = texture.Height / numberFrame;

        }
        
        //The Draw method, it's override so it calls the base method too
        public override void Draw()
        {



            base.Draw();

        }

    }
}
