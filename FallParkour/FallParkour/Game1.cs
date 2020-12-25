using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FallParkour.Map;
using System;

namespace FallParkour
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        LevelDesign level;

        private Texture2D texture;
        Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            level = new LevelDesign(Content);
            level.CreateWorld();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("Pink_Monster_Walk_6");
            // TODO: use this.Content to load your game content here

            InitializeGameObjects();
        }



        private void InitializeGameObjects()
        {
            player = new Player(texture);
        }   

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update();

            base.Update(gameTime);
        }   

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //player.Draw(_spriteBatch);
            level.DrawWorld(_spriteBatch);
            _spriteBatch.Draw(texture, new Vector2(10, 10), new Rectangle(10, 10, 10, 10), Color.White);

            _spriteBatch.End();





            base.Draw(gameTime);
        }
    }
}
