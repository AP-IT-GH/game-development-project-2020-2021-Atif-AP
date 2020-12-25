using FallParkour.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Map
{
    class LevelDesign
    {
        public Texture2D texture;
        private Blok[,] blokArray = new Blok[11, 10];
        private ContentManager content;

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0 },
            {0,1,0,0,0,0,0,0,0,0 },
            {0,0,0,1,0,0,1,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,1,0,0,1,1,0,0,1,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,1,0,1,0,1,1,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,1,0,0,1,1,1,0,1,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,1,1,1,1,1,1,1,1,0 },
        };

        public LevelDesign (ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            texture = content.Load<Texture2D>("blok");
        }

        public void CreateWorld()
        {
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Blok(texture, new Vector2(y * 128, x * 64));
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
