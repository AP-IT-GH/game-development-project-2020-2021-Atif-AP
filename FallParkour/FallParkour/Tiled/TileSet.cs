using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Tiled
{
    class TileSet
    {
        public int TileCount, TileWidth, TileHeight, Columns;
        string Asset;
        public Texture2D Texture;
        public List<Tile> Tiles;
        public TileSet(int tileWidth, int tileHeight, int tileCount, int columns, string asset, List<Tile> tiles)
        {
            TileCount = tileCount;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Asset = asset;
            Columns = columns;
            Tiles = tiles;
        }

        public Vector2 GetTileLocation(int tileId)
        {
            int x = 0, y = 0;
            if (tileId != 0)
            {
                x = (tileId % Columns) * TileWidth;
                y = (tileId >= Columns) ? (tileId / Columns) * TileHeight : 0;
            }
            return new Vector2(x, y);
        }

        public Rectangle GetTileRectangle(int tileId)
        {
            Vector2 location = GetTileLocation(tileId);
            return new Rectangle((int)location.X, (int)location.Y, TileWidth, TileHeight);
        }

        public void LoadTexture(Texture2D texture)
        {
            Texture = texture;
        }
    }
}
