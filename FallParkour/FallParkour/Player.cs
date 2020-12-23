using FallParkour.Animation;
using FallParkour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour
{
    class Player:IGameObject
    {
        Texture2D heroTexture;
        Animatie animatie;
        Vector2 position, velocity;
        const float gravity = 100f;
        float jumpSpeed = 500f;
        float moveSpeed = 500f;
        bool jump = true;

        public Player(Texture2D texture)
        {
            heroTexture = texture;
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(160, 0, 32, 32)));
        }

        public void Initialize()
        {
            position = velocity = Vector2.Zero;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            GameTime gameTime = new GameTime();

            if(state.IsKeyDown(Keys.Right))
            {
                velocity.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                animatie.Update();
            }
            if (state.IsKeyDown(Keys.Left))
            {
                velocity.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                animatie.Update();
            }
            if (state.IsKeyDown(Keys.Up) && jump)
            {
                velocity.Y = -jumpSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                jump = false;
            }

            if (!jump)
            {
                velocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                velocity.Y = 0;
            }

            velocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += velocity;

            position.X += velocity.X;

            jump = position.Y >= 150;

            if (jump)
            {
                position.Y = 150;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
