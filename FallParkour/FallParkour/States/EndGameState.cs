using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using FallParkour.Controls;

namespace FallParkour.States
{
    class EndGameState : State
    {

        private List<Component> _components;
        private SpriteFont font_12, font_64;

        public EndGameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, content)
        {
            var buttonTexture = _content.Load<Texture2D>("blok");
            font_12 = _content.Load<SpriteFont>("font_12");
            font_64 = _content.Load<SpriteFont>("font_64");

            var restartGameButton = new Button(buttonTexture, font_12)
            {
                Position = new Vector2(550, 300),
                Text = "Restart",
            };

            restartGameButton.Click += restartGameButton_Click;

            var quitGameButton = new Button(buttonTexture, font_12)
            {
                Position = new Vector2(550, 400),
                Text = "Quit",
            };

            _components = new List<Component>()
            {
                restartGameButton,
                quitGameButton,
            };

            quitGameButton.Click += quitGameButton_Click;
        }

        private void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void restartGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font_64, "You Have Completed", new Vector2(250, 50), Color.White);
            spriteBatch.DrawString(font_64, "Fall Parkour", new Vector2(400, 140), Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }
    }
}
