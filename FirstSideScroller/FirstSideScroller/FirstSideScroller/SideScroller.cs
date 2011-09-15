using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FirstSideScroller
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SideScroller : Microsoft.Xna.Framework.Game
    {

        //These vars are static because i need to reference them in other files
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static Texture2D mapTexture;

        //The player var
        Player p1;

        Entity[] entities = new Entity[20];

        public SideScroller()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //The map texture
            mapTexture = Content.Load<Texture2D>("Map3");

            //Here we load the player texture and the player itself
            p1 = new Player(new Vector2(100,100), Content.Load<Texture2D>("Char"), 2);

            entities[0] = new Entity(new Vector2(300, 300), Content.Load<Texture2D>("Char2"));
            entities[0].source = new Rectangle(0, 0, entities[0].texture.Width, entities[0].texture.Height / 2);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            //Call the player update method
            p1.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Create a new matrix, this matrix is useful to create a camera system in the game, the camera will follow the position
            //This "camera" method wasn't created by me, i'm just using some parts of the system
            Matrix viewMatrix = new Matrix();

            //This var is useful so we can apply the next 4 if's, they're going to check if the position is in the Viewport + Map bounds
            Vector2 cameraPosition = p1.position;

            if (cameraPosition.X < (GraphicsDevice.Viewport.Width / 2.0f))
            {

                cameraPosition = new Vector2(GraphicsDevice.Viewport.Width / 2.0f, cameraPosition.Y);

            }
            else if(cameraPosition.X>(mapTexture.Width-(GraphicsDevice.Viewport.Width/2.0f)))
            {

                cameraPosition = new Vector2((mapTexture.Width - (GraphicsDevice.Viewport.Width / 2.0f)), cameraPosition.Y);

            }

            if (cameraPosition.Y < (GraphicsDevice.Viewport.Height / 2.0f))
            {

                cameraPosition = new Vector2(cameraPosition.X, GraphicsDevice.Viewport.Height / 2.0f);

            }
            else if (cameraPosition.Y > (mapTexture.Height - (GraphicsDevice.Viewport.Height / 2.0f)))
            {

                cameraPosition = new Vector2(cameraPosition.X, (mapTexture.Height - (GraphicsDevice.Viewport.Height / 2.0f)));

            }

            //Create a translation from the camera position (i'm still trying to figure out why the position needs to be negative .-.)
            viewMatrix = Matrix.CreateTranslation(new Vector3(-cameraPosition, 0.0f));

            //Create a new vector2 that defines the origin (position) of the camera. Here we use the viewPort so we can adjust the camera to the Screen Size)
            Vector2 origin = new Vector2(GraphicsDevice.Viewport.Width/2.0f,GraphicsDevice.Viewport.Height/2.0f);

            //These methods are useful to rotate and apply zoom to the Camera
            //viewMatrix = viewMatrix * Matrix.CreateRotationZ(MathHelper.ToRadians(90));
            //viewMatrix = viewMatrix * Matrix.CreateScale(0.5f);

            //Here we create a translation of the origin and multiply by the current matrix (yeah i suck at matrix and i'm still trying to figure it out too :X)
            viewMatrix = viewMatrix * Matrix.CreateTranslation(new Vector3(origin, 0.0f));

            //Here we use a different Begin method so we can use the matrix to change the game "Camera" position
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,null,viewMatrix);

            //Draw the map (use the Vector2.Zero as position because the bounds use the Vector2.Zero as origin)
            spriteBatch.Draw(mapTexture, Vector2.Zero, Color.White);

            foreach (Entity ent in entities)
            {

                if (ent != null)
                {
                    ent.Draw(gameTime);
                }

            }
            
            //Call the player draw method
            p1.Draw(gameTime);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
