using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Support;
using System;
using System.Collections.Generic;

namespace MyGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager sGraphics;
        public static SpriteBatch sSpriteBatch;
        public static ContentManager sContent;
        public static Random sRandom = new Random();

        int windowWidth = 1000;
        int windowHeight = 800;

        GameState gameState;

        

        Scrolling scrolling1;
        Scrolling scrolling2;//3.38min vid:XNA TUTORIAL 9 - Scrolling Background
        Scrolling scrolling3;
        Sanic sanic;
       

        public Game1()
        {
            sGraphics = new GraphicsDeviceManager(this);
            sGraphics.PreferredBackBufferWidth = windowWidth;
            sGraphics.PreferredBackBufferHeight = windowHeight;

            Content.RootDirectory = "Content";
            sContent = Content;
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            Support.Camera.Setup();
            Support.Font.Setup();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            sSpriteBatch = new SpriteBatch(GraphicsDevice);
            gameState = new GameState();
            scrolling1 = new Scrolling(Content.Load<Texture2D>("background1"), new Rectangle(0, 0, 1000, 500));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("background1"), new Rectangle(0, 500, 1000, 500));
            scrolling3 = new Scrolling(Content.Load<Texture2D>("background1"), new Rectangle(0, 1000, 1000, 500));
            sanic = new Sanic(new Vector2(0,0.8f));

            




        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (scrolling1.rectangle.Y + scrolling1.texture.Height <= 100)
                scrolling1.rectangle.Y += 1500;
            if (scrolling2.rectangle.Y + scrolling2.texture.Height <= 100)
                scrolling2.rectangle.Y += 1500 ;
            if (scrolling3.rectangle.Y + scrolling3.texture.Height <= 100)
                scrolling3.rectangle.Y += 1500;

            sanic.Update(gameTime);
            scrolling1.Update();
            scrolling2.Update();
            scrolling3.Update();

            

            gameState.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            sSpriteBatch.Begin();

            scrolling1.Draw(sSpriteBatch);
            scrolling2.Draw(sSpriteBatch);
            scrolling3.Draw(sSpriteBatch);

            sanic.Draw();

            gameState.Draw(gameTime);
            sSpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
