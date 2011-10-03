using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DSotB
{
    public class Player : Entity
    {

        int frameNumber = 0;
        int frameHeight;

        float speed = 1;

        int horizontalD = 0;
        int verticalD = 0;

        int lives = 3;

        KeyboardState lastKstate;

        public Player(int numberFrames, Texture2D playerTexture, Vector2 initialPos)
        {

            texture = playerTexture;
            position = initialPos;
            frameHeight = texture.Height / numberFrames;

        }

        public override void Update(GameTime gameTime)
        {

            Vector2 nextPosition = position;

            KeyboardState currentKstate = Keyboard.GetState();

            if (lastKstate != currentKstate)
            {

                verticalD = 0;
                horizontalD = 0;

                if (currentKstate.IsKeyDown(Keys.Up))
                {

                    verticalD = -1;

                }
                else if (currentKstate.IsKeyDown(Keys.Down))
                {

                    verticalD = 1;

                }

                if (currentKstate.IsKeyDown(Keys.Right))
                {

                    horizontalD = 1;

                }
                else if (currentKstate.IsKeyDown(Keys.Left))
                {

                    horizontalD = -1;

                }

                if (currentKstate.IsKeyDown(Keys.LeftShift))
                {

                    speed = 1;

                }
                else
                {

                    speed = 2;

                }

                lastKstate = currentKstate;

            }

            nextPosition += new Vector2(speed * horizontalD, speed * verticalD);

            if (nextPosition.X+texture.Width > DSotB.GAME_WIDTH)
            {

                nextPosition = new Vector2(DSotB.GAME_WIDTH-texture.Width, nextPosition.Y);

            }
            else if (nextPosition.X < 0)
            {

                nextPosition = new Vector2(0, nextPosition.Y);

            }
            if ((nextPosition.Y+frameHeight) > DSotB.GAME_HEIGHT)
            {

                nextPosition = new Vector2(nextPosition.X, DSotB.GAME_HEIGHT - frameHeight);

            }

            else if (nextPosition.Y < 0)
            {

                nextPosition = new Vector2(nextPosition.X, 0);

            }

            position = nextPosition;

            hitBox = new Rectangle((int)position.X + texture.Width / 8, (int)position.Y + frameHeight / 8, texture.Width * 3 / 4, frameHeight * 3 / 4);
            
            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {

            source = new Rectangle(0, frameNumber, texture.Width, frameHeight);

            base.Draw(gameTime);

        }

        public void ShotCollision()
        {

            lives--;

            position = new Vector2(50, 50);

        }
    }
}
