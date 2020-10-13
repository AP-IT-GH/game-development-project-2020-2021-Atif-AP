using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Tiled.JsonModels
{
    class TileMapJson
    {
        public int height, width, tileheight, tilewidth;
        public List<TileMapTileset> tilesets;
        public List<TileMapLayer> layers;
    }
}
