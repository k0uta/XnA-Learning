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

namespace DSotB
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class DSotB : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public const int GAME_WIDTH = 800;
        public const int GAME_HEIGHT = 400;

        public static Player p1;

        EnemyShot[] exampleshot = new EnemyShot[20];


        public DSotB()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = GAME_WIDTH;
            graphics.PreferredBackBufferHeight = GAME_HEIGHT;
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

            p1 = new Player(2, Content.Load<Texture2D>("PModel1"), new Vector2(50, 50));

            //exampleshot[0] = new HorizontalShot(new Vector2(400, 200), Content.Load<Texture2D>("ExampleShot"), 1,1);
            exampleshot[1] = new AngleShot(new Vector2(400, 200), Content.Load<Texture2D>("ExampleShot"), 1, 1, 135);
            exampleshot[2] = new AngleShot(new Vector2(400, 200), Content.Load<Texture2D>("ExampleShot"), 1, 1, 45);

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

            p1.Update(gameTime);

            foreach (EnemyShot eShot in exampleshot)
            {

                if (eShot != null)
                {

                    eShot.Update(gameTime);

                }

            }

            //exampleshot.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            p1.Draw(gameTime);

            foreach (EnemyShot eShot in exampleshot)
            {

                if (eShot != null)
                {

                    eShot.Draw(gameTime);

                }

            }

            //exampleshot.Draw(gameTime);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
