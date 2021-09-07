using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.States
{
    public abstract class State
    {
        protected Game1 _game;

        protected GraphicsDevice _graphicsDevice;

        protected ContentManager _content;

        public State(Game1 game, ContentManager content)
        {
            _game = game;
            _content = content;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void PostUpdate(GameTime gameTime);
        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;

            _graphicsDevice = graphicsDevice;

            _content = content;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
