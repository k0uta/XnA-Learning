using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DSotB
{
    public class Shot : Entity
    {

        protected int speed;

        public bool destroy = false;

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

            source = new Rectangle(0, 0, texture.Width, texture.Height);

            base.Draw(gameTime);

        }

        public override void Update(GameTime gameTime)
        {



            base.Update(gameTime);

        }

    }
}
