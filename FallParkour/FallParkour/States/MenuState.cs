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
        private SpriteFont font_12, font_24;

        public MenuState(Game1 game, GraphicsDeviceManager graphics, ContentManager content)
            : base(game, content)
        {
            var buttonTexture = _content.Load<Texture2D>("blok");
            font_12 = _content.Load<SpriteFont>("font_12");
            font_24 = _content.Load<SpriteFont>("font_24");

            var startGameButton = new Button(buttonTexture, font_12)
            {
                Position = new Vector2(600, 200),
                Text = "Start",
            };

            var quitGameButton = new Button(buttonTexture, font_12)
            {
                Position = new Vector2(600, 300),
                Text = "Quit",
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

            spriteBatch.DrawString(font_24, "Fall Parkour", new Vector2(600, 100), Color.White); 
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
