using FallParkour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Movement
{
    class playerMovement:IInputReader
    {
        Vector2 position, velocity;
        const float jumpSpeed = 4f;
        const float moveSpeed = 4f;
        float gravity;
        bool jump = false;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            GameTime gameTime = new GameTime();

            velocity = Vector2.Zero;

            if (state.IsKeyDown(Keys.Right))
            {
                velocity.X += moveSpeed;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                velocity.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
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

            jump = position.Y >= 150;

            if (jump)
            {
                position.Y = 150;
            }

            return velocity;
        }
    }
}
