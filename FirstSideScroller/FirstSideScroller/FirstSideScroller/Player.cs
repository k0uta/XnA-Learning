using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstSideScroller
{
    class Player:Entity
    {

        //Some player parameters
        protected int frameNumber;
        protected int frameSize;
        protected int frameState = 0;
        protected int frameTimer=0;
        KeyboardState oldkState;

        //The direction and speed of the player
        protected int direction=0;
        protected int speed=2;
        protected bool jumping=false;
        protected float timerJump;

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
        public override void Draw(GameTime gTime)
        {

            //Here we check if we can change the current frame of the player
            if (frameTimer > gTime.ElapsedGameTime.Milliseconds)
            {

                //If the player is moving we alternate between 1 and 0
                if (jumping || direction != 0)
                {
                    if (frameState == 0)
                    {

                        frameState++;

                    }
                    else
                    {

                        frameState--;
                    }

                }

                //Else we just use the 1st frame (the 0)
                else
                {
                    frameState = 0;

                }

                //Here we reset the timer
                frameTimer = 0;

            }

            //Increments the timer
            else
            {

                frameTimer++;

            }

            //Sets the source according to the current frame and the frame size
            source = new Rectangle(0, frameState, texture.Width, frameSize);

            base.Draw(gTime);

        }

        //The Update method
        public override void Update(GameTime gTime)
        {

            //Gets the actual keyboard state
            KeyboardState kState = Keyboard.GetState();

            //Check if the current keyboard state is different from the last keyboard state
            if (kState != oldkState)
            {

                //Check if the Spacebar is pressed
                if (kState.IsKeyDown(Keys.Space))
                {

                    //Check if the player is already jumping
                    if (!jumping)
                    {

                        //If the player is not jumping we define it true and reset the jump timer
                        jumping = true;
                        timerJump = 0 ;
                    }

                }

                //Here we check if the player is pressing the right or the left key, Then we define the direction and apply the spriteEffect to Flip the frame (i'm lazy yeah)
                else if (kState.IsKeyDown(Keys.Right))
                {

                    direction = 1;
                    spriteEffects = SpriteEffects.None;

                }

                else if (kState.IsKeyDown(Keys.Left))
                {

                    direction = -1;
                    spriteEffects = SpriteEffects.FlipHorizontally;

                }

                else
                {

                    direction = 0;

                }

            }

            //Set the old key state to the current key state
            oldkState = kState;

            //Check if the player is jumping
            if (jumping)
            {

                //If the timer that defines the "jump length" has not reached the limit time
                if (timerJump < gTime.ElapsedGameTime.Milliseconds+10 )
                {

                    //Define the gravity to a negative value so we can jump and increments the timer of jump
                    gravity = -4;
                    timerJump++;

                }
                else
                {

                    //Reset the gravity to the default value
                    gravity = 2;

                    //Here we check if the player reached the floor, so we can end the jumping state
                    Vector2 nPos = position + new Vector2(0, gravity);
                    if (checkColisionMap(nPos))
                    {
                        jumping = false;

                    }

                }

            }

            //Here we just check if the new position of the player respects the map bounds (not complete, need to add some checks)
            Vector2 newPosition = position;
            newPosition += new Vector2(speed * direction, 0);

            bool entityCollision = false;

            foreach (Entity ent in SideScroller.entities)
            {

                if (ent != null)
                {

                    if (checkColisionEntity(ent))
                    {

                        entityCollision = true;

                    }

                }

            }

            if (!checkColisionMap(newPosition) && !entityCollision)
            {

                position = newPosition;

            }

            //Lets check the gravity
            Vector2 nextPosition = position;
            nextPosition += new Vector2(0, gravity);

            entityCollision = false;

            foreach (Entity ent in SideScroller.entities)
            {

                if (ent != null)
                {

                    if (checkColisionEntity(ent))
                    {

                        entityCollision = true;

                    }

                }

            }

            if (checkColisionMap(nextPosition) || entityCollision)
            {

                //Do nothing if the next position causes a colision, this can change in the future

            }
            else
            {

                //If the next position did not collided with anything in the map texture we define that the next position is safe
                position = nextPosition;

            }
            
            base.Update(gTime);

        }

    }
}
