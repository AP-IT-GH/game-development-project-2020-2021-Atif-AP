﻿using FallParkour.Animation;
using FallParkour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Sprites
{
    class Hero : Sprite
    {
        public Hero(Texture2D texture)
      : base(texture)
        {
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(160, 0, 32, 32)));
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            Position += Velocity;
            Velocity = Vector2.Zero;

            if (Position !=  Position + Velocity)
            {
                animatie.Update();
            }
        }

        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;
        }
    }
}
