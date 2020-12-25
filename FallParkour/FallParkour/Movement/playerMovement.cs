using FallParkour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Movement
{
    class PlayerMovement:IInputReader
    {
        Vector2 velocity;
        const float jumpSpeed = 100f;
        const float moveSpeed = 4f;
        float gravity = 1f;
        bool jump = true;

        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();

            velocity = Vector2.Zero;

            if (state.IsKeyDown(Keys.Right))
            {
                velocity.X += moveSpeed;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                velocity.X -= moveSpeed;
            }
            if (state.IsKeyDown(Keys.Up) && jump == true)
            {
                velocity.Y -= jumpSpeed;
                jump = false;
            }

            if (jump == false)
            {
                velocity.Y += 0.30f * gravity;
            }
            else
            {
                velocity.Y = 0f;
                jump = true;
            }

            return velocity;
        }
    }
}
