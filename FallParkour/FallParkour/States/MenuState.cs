using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using FallParkour.Controls;
using System.ComponentModel;

namespace FallParkour.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        private SpriteFont font_12, font_64;

        public MenuState(Game1 game, GraphicsDeviceManager graphics, ContentManager content)
            : base(game, content)
        {
            var buttonTexture = _content.Load<Texture2D>("blok");
            font_12 = _content.Load<SpriteFont>("font_12");
            font_64 = _content.Load<SpriteFont>("font_64");

            var startGameButton = new Button(buttonTexture, font_12)
            {
                Position = new Vector2(550, 300),
                Text = "Start",
            };

            startGameButton.Click += startGameButton_Click;

            var quitGameButton = new Button(buttonTexture, font_12)
            {
                Position = new Vector2(550, 400),
                Text = "Quit",
            };

            _components = new List<Component>()
            {
                startGameButton,
                quitGameButton,
            };

            quitGameButton.Click += quitGameButton_Click;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font_64, "Fall Parkour", new Vector2(400, 50), Color.White); 
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void LoadContent()
        {
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }
    }
}
