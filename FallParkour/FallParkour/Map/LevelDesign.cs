using FallParkour.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace FallParkour.Map
{
    class LevelDesign
    {
        private ContentManager content;

        public TmxMap map;
        Texture2D tileset;

        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
        int tilesetTilesHigh;
        private List<Rectangle> collisionObjects;

        public LevelDesign (ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
        }

        public void LoadContent(string name)
        {
            map = new TmxMap("Content/"+name+".tmx");
            tileset = content.Load<Texture2D>(map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;

            /*foreach(var c in map.ObjectGroups[0].Objects)
            {
                collisionObjects.Add(new Rectangle((int)c.X, (int)c.Y, (int)c.Width, (int)c.Height));
            }*/
        }

        public void Update(Sprite sprite)
        {
            bool IsCollisionTile()
            {
                foreach (Rectangle rect in collisionObjects)
                    if (rect.Intersects(sprite.Rectangle))
                        return true;

                return false;
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (var i = 0; i < map.Layers[0].Tiles.Count; i++)
            {
                int gid = map.Layers[0].Tiles[i].Gid;

                // Empty tile, do nothing
                if (gid == 0)
                {

                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                    spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                }
            }
        }
    }
}
