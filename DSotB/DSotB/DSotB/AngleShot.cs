using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DSotB
{
    public class AngleShot : EnemyShot
    {

        protected double angle;

        public AngleShot(Vector2 position, Texture2D texture, int shotSpeed, int shotOrientation, double shotAngle)
            : base(position, texture)
        {

            speed = shotSpeed * shotOrientation;

            angle = Math.PI * shotAngle / 180.0;

        }

        public override void Update(GameTime gameTime)
        {

            position += new Vector2((float)(Math.Cos(angle)*speed), (float)(Math.Sin(angle)*speed));

            base.Update(gameTime);

        }

    }
}
