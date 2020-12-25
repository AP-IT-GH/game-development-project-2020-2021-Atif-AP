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
        IInputReader inputReader;

        public Player(Texture2D texture, IInputReader reader)
        {
            heroTexture = texture;
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(160, 0, 32, 32)));

            this.inputReader = reader;
        }

        public void Initialize()
        {
            position.X = 600;
            position.Y = 600;
        }

        public void Update()
        {
            var velocity = inputReader.ReadInput();
            if (position != position + velocity)
            {
                position += velocity;
                animatie.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
