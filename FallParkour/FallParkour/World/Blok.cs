using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.World
{
    class Blok
    {
        public Texture2D Texture { get; set; }
        public Vector2 Positie { get; set; }

        public Blok(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Positie = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, Color.AliceBlue);
        }
    }
}
