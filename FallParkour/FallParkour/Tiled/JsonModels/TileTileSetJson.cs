using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Tiled.JsonModels
{
    class TileTileSetJson
    {
        public int columns, imagewidth, imageheight, tilecount;
        public string image;
        public List<TileTileSetTileJson> tiles;
    }
}
