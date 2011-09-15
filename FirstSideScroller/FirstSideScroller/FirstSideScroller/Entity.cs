using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstSideScroller
{
    class Entity
    {

        //The position Vector
        public Vector2 position;

        //The entity texture
        public Texture2D texture;

        //The source rectangle, pointing where (X and Y) and the size of the entity
        public Rectangle source;

        //Sprite Effects (in case we need)
        protected SpriteEffects spriteEffects;

        //The gravity
        protected float gravity=2;

        //The constructor
        public Entity(Vector2 pos, Texture2D tex)
        {
            //Set the position and the texture
            position = pos;
            texture = tex;

            //Intializes the source rectangle to avoid errors
            source = new Rectangle(0, 0, tex.Width, tex.Height);

        }

        //The draw method
        public virtual void Draw(GameTime gTime)
        {

            //Draw the entity using the parameters
            //SideScroller.spriteBatch.Draw(texture, position, source, Color.White);
            SideScroller.spriteBatch.Draw(texture, position, source, Color.White,0,Vector2.Zero,1.0f,spriteEffects,0);

        }

        //The update method
        public virtual void Update(GameTime gTime)
        {

            //Lets check the gravity
            Vector2 nextPosition = position;
            nextPosition += new Vector2(0,gravity);

            if (checkColisionMap(nextPosition))
            {

                //Do nothing if the next position causes a colision, this can change in the future

            }
            else
            {

                //If the next position did not collided with anything in the map texture we define that the next position is safe
                position = nextPosition;

            }

        }

        //The CheckColisionMap
        public bool checkColisionMap(Vector2 nextPos)
        {

            //So first we create a new Render Target, this var is used to render the next game state without actually doing it in the player screen
            RenderTarget2D nextRender = new RenderTarget2D(SideScroller.graphics.GraphicsDevice, source.Width,source.Height);

            //We create this rectangle so we can check only an certain area of the texture
            Rectangle testArea = new Rectangle((int)nextPos.X, (int)nextPos.Y, source.Width, source.Height);

            //I just created this vars to simplify my life
            GraphicsDevice gDev = SideScroller.graphics.GraphicsDevice;
            SpriteBatch sBatch = SideScroller.spriteBatch;

            //This var defines the number of pixels that we are going to analyze
            int numberPixels = source.Width * source.Height;

            //Here we change the current render target of the game (probably it's null)
            gDev.SetRenderTarget(nextRender);

            //Now we clear the current render
            gDev.Clear(ClearOptions.Target, Color.CornflowerBlue, 0, 0);

            //Here we just start the spritebatch so we can draw
            sBatch.Begin();

            //Here we draw what would be the test area of the map texture
            sBatch.Draw(SideScroller.mapTexture, Vector2.Zero,testArea, Color.White);

            sBatch.End();

            //Here we set the render target to the default render
            gDev.SetRenderTarget(null);

            //This var will store the colors from each pixel of the test area
            Color[] colorTexture = new Color[numberPixels];

            //This method gets all the colors of the test area and put them in the colorTexture var
            nextRender.GetData<Color>(colorTexture);

            //Now we pass through each color extracted from the test area
            foreach (Color colorT in colorTexture)
            {

                //If the color is not white we define that there were a collision
                if (colorT != Color.White)
                {

                    return true;

                }

            }

            //If there were no collision we return the false statement
            return false;

        }

        //Now i'm going to check if there were a collision between two entitys
        public bool checkColisionEntity(Entity targetEntity)
        {

            //Actually this is pretty easy, we make 2 rectangles and check if they intersect
            return source.Intersects(targetEntity.source);

        }
    }
}
