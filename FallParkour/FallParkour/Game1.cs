using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FallParkour.Map;
using System;
using FallParkour.Movement;
using FallParkour.States;

namespace FallParkour
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScreenWidth = 1920;
        public static int ScreenHeight = 1080;

        private State _currentState;
        private State _nextState;

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

            _currentState = new MenuState(this, _graphics, Content);
            _nextState = null;

            texture = Content.Load<Texture2D>("Pink_Monster_Walk_6");
            // TODO: use this.Content to load your game content here

            InitializeGameObjects();
        }



        private void InitializeGameObjects()
        {
            player = new Player(texture, new PlayerMovement());
            player.Initialize();
        }   

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }
            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            // TODO: Add your update logic here
            player.Update();

            base.Update(gameTime);
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _currentState.Draw(gameTime, _spriteBatch);

            _spriteBatch.Begin();

            player.Draw(_spriteBatch);
            level.DrawWorld(_spriteBatch);

            _spriteBatch.End();





            base.Draw(gameTime);
        }
    }
}
