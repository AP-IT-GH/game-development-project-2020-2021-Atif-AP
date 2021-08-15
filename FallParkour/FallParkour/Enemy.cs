using FallParkour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour
{
    class Enemy : IGameObject
    {
        Vector2 position;
        Texture2D enemyTexture;

        public Enemy(Texture2D texture)
        {
            enemyTexture = texture;
        }


        public void Initialize()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, position, Color.White);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
