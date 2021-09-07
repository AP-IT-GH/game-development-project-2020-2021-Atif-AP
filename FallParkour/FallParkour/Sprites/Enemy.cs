using FallParkour.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Sprites
{
    class Enemy : Sprite
    {
        public Enemy(Texture2D texture) : base(texture)
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
        }
    }
}
