using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DSotB
{
    public class EnemyShot : Shot
    {

        public void playerCollision(ref Player target)
        {

            if (target!=null && CheckCollision(target))
            {

                destroy = true;

                target.ShotCollision();

            }

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            hitBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            playerCollision(ref DSotB.p1);

            if (position.X < -100||position.Y<-100||position.Y>DSotB.GAME_HEIGHT+100)
            {

                destroy = true;

                position = new Vector2(400, 200);

            }

            base.Update(gameTime);

        }

        public EnemyShot(Vector2 posi, Texture2D text)
        {

            position = posi;
            texture = text;

        }

    }
}
