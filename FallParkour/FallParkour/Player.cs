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
        Vector2 position;

        public Player(Texture2D texture)
        {
            heroTexture = texture;
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(140, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(162, 0, 32, 32)));
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if(state.IsKeyDown(Keys.Right))
            {
                position.X += 10;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                position.X -= 10;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                position.X += 10;
            }

            animatie.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10), animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
