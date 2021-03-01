using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

namespace Scream.SonaruIsugeTank
{
    [CustomEditor(typeof(TilemapGenerator)), ExecuteAlways]
    class TilemapGeneratorEditor : Editor
    {

        Dictionary<TileBase, TileBase> alternativeTileDics = null;

        void OnEnable() => Tilemap.tilemapTileChanged += HandleTilemapTileChanged;

        void OnDisable() => Tilemap.tilemapTileChanged -= HandleTilemapTileChanged;

        void HandleTilemapTileChanged(Tilemap tilemap, Tilemap.SyncTile[] tiles)
        {
            var tg = target as TilemapGenerator;
            if (alternativeTileDics == null)
            {
                alternativeTileDics = new Dictionary<TileBase, TileBase>();
                foreach (var o in tg.AlternativeTilemaps)
                    alternativeTileDics.Add(o.From, o.To);
            }

            var tgm = tg.TilemapToChange;
            foreach (var tile in tiles)
            {
                if (tile.tile != null && alternativeTileDics.ContainsKey(tile.tile))
                    tgm.SetTile(tile.position, alternativeTileDics[tile.tile]);
                else if (tile.tile == null)
                    tgm.SetTile(tile.position, null);

            }
            tgm.RefreshAllTiles();
        }


    }
}