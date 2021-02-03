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
        private SpriteFont buttonFont;

        public MenuState(Game1 game, GraphicsDeviceManager graphics, ContentManager content)
            : base(game, content)
        {
            var buttonTexture = _content.Load<Texture2D>("blok");
            buttonFont = _content.Load<SpriteFont>("Font");

            var startGameButton = new Button(buttonTexture, buttonFont)
            {
                Text = "Start",
                Position = new Vector2(300, 200),
            };

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Text = "Quit",
                Position = new Vector2(300, 300),
            };

            _components = new List<Component>()
            {
                startGameButton,
                quitGameButton,
            };
        }


        public override void LoadContent()
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
