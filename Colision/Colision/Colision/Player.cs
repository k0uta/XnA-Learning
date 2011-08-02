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
        protected float playerSpeed = 1.0f;

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
        public override void Update(GameTime gTime)
        {
            
            //Get the current state of the Keyboard
            KeyboardState kState = Keyboard.GetState();

            //Checks if the Keyboard State changed since the last update
            if (lastKstate != kState)
            {

                //Here we can put everything that refers to changes in the input

                //Defines the last keyboard state to the current keyboard state
                lastKstate = kState;

            }
            


            //Calls the Entity Update function
            base.Update(gTime);

        }

    }
}
