using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FallParkour.Map;
using System;
using FallParkour.Movement;
using FallParkour.States;
using FallParkour.Sprites;
using System.Collections.Generic;
using FallParkour.Models;

namespace FallParkour
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;

        private State _currentState;
        private State _nextState;

        public static Texture2D texture;

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
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("block_player2");

            _currentState = new MenuState(this, _graphics, Content);

            InitializeGameObjects();
        }



        private void InitializeGameObjects()
        {
        }   

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextState != null)
            {
                _currentState = _nextState;
            }
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
