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
using memorialfight.objects;
using memorialfight.objects.actor;

namespace memorialfight
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        // Stuff to put in a class
        Player player1;
        EnvironmentObject ground;

        LinkedList<EnvironmentObject> world;

        public Game1()
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
            graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            //graphics.ToggleFullScreen();
            graphics.ApplyChanges();

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

            // TODO: use this.Content to load your game content here
            world = new LinkedList<EnvironmentObject>();


            // Build WorldObject for testing. Need a better player texture.
            Texture2D sprite1 = Content.Load<Texture2D>("sprites/sprite1");
            Vector2 sprite1Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);
            Rectangle sprite1Rect = new Rectangle((int)sprite1Position.X, (int)sprite1Position.Y, sprite1.Width, sprite1.Height);
            player1 = new Player(sprite1Position, sprite1Rect, sprite1, 1);
            
            // Ground
            Texture2D woodTex = Content.Load<Texture2D>("sprites/wood");
            Vector2 groundPosition = new Vector2(0, graphics.GraphicsDevice.Viewport.Height-400);
            Console.WriteLine(graphics.GraphicsDevice.Viewport.Height.ToString());
            Rectangle groundRect = new Rectangle((int)groundPosition.X, (int)groundPosition.Y, 120, 120);

            float groundPosY = groundPosition.Y;
            for (int i = 0; i < 16; i++)
            {
                if (i == 0 || i == 15)
                {
                    groundPosition = new Vector2(120 * i, groundPosY - 120);
                    groundRect = new Rectangle((int)groundPosition.X, (int)groundPosition.Y, 120, 120);
                }
                else
                {
                    groundPosition = new Vector2(120 * i, groundPosY);
                    groundRect = new Rectangle((int)groundPosition.X, (int)groundPosition.Y, 120, 120);
                }
                
                world.AddLast(new EnvironmentObject(groundPosition, groundRect, woodTex));
            }
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

            player1.MovePlayer(Keyboard.GetState());
            player1.Update(world);

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
            spriteBatch.Begin();
            // wObjTest works! Now onto the actor class then player class.
            player1.Draw(spriteBatch);
            for (int i = 0; i < world.Count; i++)
            {
                world.ElementAt(i).Draw(spriteBatch);
            }
            //ground.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
