using FallParkour.Tiled.JsonModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using FallParkour.Utilities;

namespace FallParkour.Tiled
{
    class TileMapConverter
    {
        public static TileMap GetTileMap(string TiledMapJsonFile)
        {
            TileMap map = new TileMap();

            TileMapJson jsonMap = JsonConvert.DeserializeObject<TileMapJson>(File.ReadAllText(TiledMapJsonFile));

            Debug.WriteLine("Tiled map has " + jsonMap.width * jsonMap.height + " tiles");
            map.Columns = jsonMap.width;
            map.Rows = jsonMap.height;
            map.TileWidth = jsonMap.tilewidth;
            map.TileHeight = jsonMap.tileheight;

            for (int i = 0; i < jsonMap.layers.Count; i++)
            {
                map.Layers.Add(new TileLayers(jsonMap.layers[i].data, jsonMap.layers[i].id));
            }

            for (int i = 0; i < jsonMap.tilesets.Count; i++)
            {
                string json = File.ReadAllText(TiledMapJsonFile.Substring(0, TiledMapJsonFile.LastIndexOf('\\') + 1) + jsonMap.tilesets[i].source);
                TileTileSetJson jsonTileset = JsonConvert.DeserializeObject<TileTileSetJson>(json);
                List<Tile> tiles = new List<Tile>();

                for (int j=0; j < jsonTileset.tilecount; j++)
                {
                    tiles.Add(new Tile(jsonTileset.tiles[j].id, jsonTileset.tiles[j].properties[0].value));
                }
                map.Tilesets.Add(new TileSet(map.TileWidth, map.TileHeight, jsonTileset.tilecount, jsonTileset.columns, FileLocationHelper.RemoveFileExtension(FileLocationHelper.GetFileName(jsonTileset.image)), tiles));
            }
            return map;

        }

    }
}
