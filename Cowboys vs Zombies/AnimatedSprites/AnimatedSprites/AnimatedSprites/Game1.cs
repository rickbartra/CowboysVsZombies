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

namespace AnimatedSprites
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        // Texture stuff
        Texture2D texture;
        Point frameSize = new Point(442, 550);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(4, 1);
        Texture2D background;

        // Framerate stuff
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 500;

        //size of screen
        Rectangle mainFrame;

        //size
        float size = .07f;

 
        //position of zombie
        Vector2 zombiePos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 512;
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

            //position for some of the images
            zombiePos = new Vector2(200, 50);

            //load images
            background = Content.Load<Texture2D>("road");
            texture = Content.Load<Texture2D>("zombieWalking");

            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
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
            KeyboardState keyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

          timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            { timeSinceLastFrame -= millisecondsPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                size += .001f;
                zombiePos.X = zombiePos.X - .001f; 
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                size -= .001f;
                //zombiePos.X = zombiePos.X - 50; 
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

          //  spriteBatch.Draw(background, mainFrame, Color.White);

            
            spriteBatch.Draw(texture, new Vector2(zombiePos.X, zombiePos.Y),
            new Rectangle(currentFrame.X * frameSize.X,
            currentFrame.Y * frameSize.Y,
            frameSize.X,
            frameSize.Y),
            Color.White, 0, Vector2.Zero,
            size, SpriteEffects.None, 0);

            spriteBatch.Draw(texture, new Vector2(zombiePos.X +100, zombiePos.Y),
            new Rectangle(currentFrame.X * frameSize.X,
            currentFrame.Y * frameSize.Y,
            frameSize.X,
            frameSize.Y),
            Color.White, 0, Vector2.Zero,
            size, SpriteEffects.None, 0);

            spriteBatch.Draw(texture, new Vector2(zombiePos.X+200, zombiePos.Y),
            new Rectangle(currentFrame.X * frameSize.X,
            currentFrame.Y * frameSize.Y,
            frameSize.X,
            frameSize.Y),
            Color.White, 0, Vector2.Zero,
            size, SpriteEffects.None, 0);
       

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
