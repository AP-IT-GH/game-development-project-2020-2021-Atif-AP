using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FallParkour.Tiled
{
    class TileMap
    {
        public Vector2 TilePos;
        public int Columns, Rows, TileWidth, TileHeight;
        public List<TileSet> Tilesets;
        public List<TileLayers> Layers;

        public TileMap()
        {
            Tilesets = new List<TileSet>();
            Layers = new List<TileLayers>();
        }

        public bool getCollisions(Vector2 PlayerPos)
        {
            bool isGrounded = false;

            if ((PlayerPos.X > 30 && PlayerPos.X < 500 && PlayerPos.Y > 250 && PlayerPos.Y < 260) || (PlayerPos.X > 520 && PlayerPos.X < 580 && PlayerPos.Y > 275 && PlayerPos.Y < 285) || ())
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            return isGrounded;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 PlayerPos)
        {
            foreach (TileLayers layer in Layers)
            {
                Debug.WriteLine("drawing layer " + layer.DrawOrderNumber + " at depth " + (Layers.Count - layer.DrawOrderNumber));
                for (int i = 0; i < layer.Tiles.Length; i++)
                {
                    if (layer.Tiles[i] != 0)
                    {
                        spriteBatch.Draw(
                            Tilesets[0].Texture,
                            GetDestinationRectangle(i, PlayerPos),
                            Tilesets[0].GetTileRectangle(layer.Tiles[i] - 1),
                            Color.White,
                            0f,
                            Vector2.Zero,
                            SpriteEffects.None,
                            0.9f / layer.DrawOrderNumber);
                    }
                }
            }
        }


        private Rectangle GetDestinationRectangle(int column, int row)
        {
            return new Rectangle(column * TileWidth, row * TileHeight, TileWidth, TileHeight);
        }

        private Rectangle GetDestinationRectangle(int mapTileId, Vector2 PlayerPos)
        {
            int x = 0, y = 0;
            if (mapTileId != 0)
            {
                x = (mapTileId % Columns) * TileWidth;
                y = (mapTileId >= Columns) ? (mapTileId / Columns) * TileHeight : 0;
            }
            return new Rectangle(x, y, TileWidth, TileHeight);
        }

        public void TestDestinationRectangle()
        {
            for (int i = 0; i < Layers[0].Tiles.Length; i++)
            {
                Rectangle dest = GetDestinationRectangle(i, new Vector2(0, 0));
            }
        }

    }
}
