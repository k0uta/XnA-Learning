using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DSotB
{
    public class HorizontalShot : EnemyShot
    {

        public HorizontalShot(Vector2 position, Texture2D texture, int shotSpeed, int shotOrientation)
            : base(position, texture)
        {

            speed = shotSpeed * shotOrientation;

        }

        public override void Update(GameTime gameTime)
        {

            position += new Vector2(-speed, 0);

            base.Update(gameTime);

        }

    }
}
