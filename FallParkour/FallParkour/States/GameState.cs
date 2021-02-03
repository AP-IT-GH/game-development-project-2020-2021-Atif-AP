using FallParkour.Map;
using FallParkour.Models;
using FallParkour.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.States
{
    class GameState : State
    {
        private GraphicsDevice _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;
        LevelDesign level;

        private Texture2D texture = Game1.texture;

        public GameState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, content)
        {
        }

        public override void LoadContent()
        {
            _sprites = new List<Sprite>()
            {
                new Hero(texture)
                {
                    Input = new Input()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Up = Keys.Up,
                        Down = Keys.Down
                    },
                    Position = new Vector2((float) Game1.ScreenWidth / 4, (float) Game1.ScreenHeight / 2 + 225),
                    Speed = 5,
                }
            };
        }

        public override void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();
            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);

            level.DrawWorld(_spriteBatch);
            _spriteBatch.End();
        }
    }
}
