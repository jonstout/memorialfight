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
using memorialfight.objects.special;

namespace memorialfight
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        // [Level] test
        Level level0;
        LinkedList<Player> players;
        LinkedList<Texture2D> level0TileSet;
        Vector2 level0Position;
        String level0TileReference;
        String level0TileType;

        // Stuff to put in a class
        Player player1;

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
            this.players = new LinkedList<Player>();
            this.level0TileSet = new LinkedList<Texture2D>();

            // Load Players.
            Texture2D sprite1 = Content.Load<Texture2D>("sprites/sprite1");
            Vector2 sprite1Position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);
            Rectangle sprite1Rect = new Rectangle((int)sprite1Position.X, (int)sprite1Position.Y, sprite1.Width, sprite1.Height);
            player1 = new Player(sprite1Position, sprite1Rect, sprite1, 1);
            // [Level] Add Player to this.players
            this.players.AddLast(player1);
            
            // Load textures
            Texture2D woodTex = Content.Load<Texture2D>("sprites/wood");
            Texture2D grassTex = Content.Load<Texture2D>("sprites/ground");
            Texture2D crateTex = Content.Load<Texture2D>("sprites/crate");
            Texture2D brickTex = Content.Load<Texture2D>("sprites/brick");

            // [Level] Initialize levels
            this.level0TileSet.AddLast(woodTex);
            this.level0TileSet.AddLast(grassTex);
            this.level0TileSet.AddLast(crateTex);
            this.level0TileSet.AddLast(brickTex);
            this.level0Position = new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 400);
            this.level0TileReference = "4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,\n,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,\n,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,\n,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,\n,4,4,3,3,3,3,0,0,0,0,0,0,0,0,0,0,4,\n,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,\n,4,4,0,0,0,0,3,3,3,0,0,0,0,0,0,0,4,\n,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,\n,4,4,1,1,0,0,0,0,0,0,3,3,0,0,0,0,4,\n,4,4,1,1,1,1,0,0,1,1,1,1,0,0,0,1,4,\n,4,4,1,1,1,1,2,2,1,1,1,1,1,2,1,1,4,\n";
            this.level0TileType = "0,0,0,0,0,\n,1,1,1,0,1,1";

            // [Level]

            Camera cam = new Camera(new Rectangle(graphics.GraphicsDevice.Viewport.X, graphics.GraphicsDevice.Viewport.Y, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height),
                this.players.ElementAt(0).pos);

            this.level0 = new Level(cam, this.players, this.level0TileSet, level0Position, this.level0TileReference, this.level0TileType);
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
            this.level0.MovePlayer1(Keyboard.GetState());
            this.level0.Update();

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
            // [Level]
            this.level0.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
