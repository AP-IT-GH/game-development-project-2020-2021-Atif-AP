using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Tiled
{
    class Tile
    {
        public int ID;
        public bool IsCollider;

        public Tile(int id, bool isCollider = false)
        {
            ID = id;
            IsCollider = isCollider;
        }

    }
}
