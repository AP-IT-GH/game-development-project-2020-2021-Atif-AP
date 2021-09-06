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
        private List<Sprite> _sprites;
        LevelDesign level;
        private bool flagNewLevel = false;

        public GameState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, content)
        {
            _sprites = new List<Sprite>()
            {
                new Hero(Game1.texture)
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
            level = new LevelDesign(content);
            LoadContent();
        }

        public override void LoadContent()
        {
            level.LoadContent("Level_1");
            if(flagNewLevel == true)
            {
                _sprites[0].Position = new Vector2((float)Game1.ScreenWidth / 4, (float)Game1.ScreenHeight / 2 + 30);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
                if (sprite.Position.Y >= 600 || sprite.Position.Y < 0 || sprite.Position.X < 0 || sprite.Position.X >= 1280)
                {
                    sprite.Position = new Vector2((float)Game1.ScreenWidth / 4, (float)Game1.ScreenHeight / 2 + 225);
                }

                if (sprite.Position.Y > 210 && sprite.Position.Y < 242 && sprite.Position.X >= 640 && sprite.Position.X <= 672)
                {
                    level.LoadContent("Level_2");
                    flagNewLevel = true;
                }

                if(flagNewLevel == true)
                {
                    if (sprite.Position.Y > 340 && sprite.Position.Y < 370 && sprite.Position.X > 1030 && sprite.Position.X < 1050)
                    {
                        _game.ChangeState(new EndGameState(_game, _graphicsDevice, _content));
                        flagNewLevel = false;

                    }
                }
            }
            level.Update(_sprites[0]);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            level.DrawWorld(spriteBatch);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }
    }
}
