using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Tiled
{
    class TileLayers
    {
        public int[] Tiles;
        public int DrawOrderNumber;
        public TileLayers(int[] tiles, int drawOrderNumber )
        {
            Tiles = tiles;
            DrawOrderNumber = drawOrderNumber;
        }

    }
}
