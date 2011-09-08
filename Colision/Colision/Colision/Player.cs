using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Colision
{
    class Player : Entity
    {

        //The name of the player
        protected String playerName;

        //The speed of the player 1 by default
        protected float playerSpeed = 10.0f;

        //The player orientation in X and Y
        protected Vector2 playerOrientation;

        //This var will tell us if the keyboard state changed since the last update
        private KeyboardState lastKstate;

        //The player constructor, basically calls the entity constructor
        public Player(Vector2 pos, Texture2D tex, Vector2 siz)
            : base(pos, tex, siz)
        {

        }

        //The Update function, this function must be override because it comes from the entity class
        public override void Update(GameTime gTime, GraphicsDeviceManager gManager, SpriteBatch sBatch)
        {
            
            //Get the current state of the Keyboard
            KeyboardState kState = Keyboard.GetState();

            GraphicsDevice gDevice = gManager.GraphicsDevice;

            //Checks if the Keyboard State changed since the last update
            if (lastKstate != kState)
            {

                //Here we can put everything that refers to changes in the input

                //The next four 'ifs' check if the Down, Up, Right or Left buttons are pressed, changing the orientation and the frame

                if (kState.IsKeyDown(Keys.Down))
                {

                    frame = new Vector2(frame.X, 0);
                    playerOrientation = new Vector2(0, 1);

                }
                else if (kState.IsKeyDown(Keys.Up))
                {

                    frame = new Vector2(frame.X, 1);
                    playerOrientation = new Vector2(0, -1);
                     
                }
                else if (kState.IsKeyDown(Keys.Right))
                {

                    frame = new Vector2(frame.X, 2);
                    playerOrientation = new Vector2(1,0);

                }
                else if (kState.IsKeyDown(Keys.Left))
                {

                    frame = new Vector2(frame.X, 3);
                    playerOrientation = new Vector2(-1, 0);

                }

                //Defines the last keyboard state to the current keyboard state
                lastKstate = kState;

            }

            //This var is used only to check if the next position respects the game limitations
            Vector2 nextPosition = position;

            //Changes the next position using the orientation and speed of the player
            nextPosition += new Vector2(playerOrientation.X * playerSpeed, playerOrientation.Y * playerSpeed);

            //Check if the next position collides with anything
            if (checkCollision(nextPosition, gDevice, sBatch) == false)
            {

                //Changes the Position using the Next Position
                position = nextPosition;

            }

            //Calls the Entity Update function
            base.Update(gTime,gManager,sBatch);

        }

        //The Draw function, just calling the Entity draw
        public override void Draw(SpriteBatch sBatch)
        {
            base.Draw(sBatch);
        }

        protected bool checkCollision(Vector2 pos,GraphicsDevice gDev, SpriteBatch sBat)
        {

            source = new Rectangle((texture.Width / (int)size.X) * (int)frame.X, (texture.Height / (int)size.Y) * (int)frame.Y, (texture.Width / (int)size.X), (texture.Height / (int)size.Y));

            RenderTarget2D nextRender = new RenderTarget2D(gDev, (int)(texture.Width / size.X), (int)(texture.Height / size.Y));

            Rectangle testArea = new Rectangle((int)pos.X, (int)pos.Y, source.Width, source.Height);

            int aPixels = source.Width * source.Height;

            gDev.SetRenderTarget(nextRender);
            gDev.Clear(ClearOptions.Target, Color.White, 0, 0);

            sBat.Begin();

            sBat.Draw(ColisionGame.mapTrack,Vector2.Zero, testArea, Color.White);

            sBat.End();

            gDev.SetRenderTarget(null);

            Color[] colorsTexture = new Color[aPixels];

            nextRender.GetData<Color>(0, new Rectangle(0, 0, testArea.Width, testArea.Height), colorsTexture, 0, aPixels);

            foreach (Color colorT in colorsTexture)
            {

                if (colorT != Color.White)
                {

                    return true;

                }

            }

            return false;

        }

    }
}
