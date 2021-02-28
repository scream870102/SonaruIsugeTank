using UnityEngine;
using UnityEngine.Tilemaps;


namespace Scream.SonaruIsugeTank
{
    [ExecuteAlways]
    class TilemapGenerator : MonoBehaviour
    {
        public AlternativeTilemap[] AlternativeTilemaps = default;
        [ExecuteAlways]
        public Tilemap TilemapToChange = null;

    }



    [System.Serializable]
    struct AlternativeTilemap
    {
        public TileBase From;
        public TileBase To;
    }
}

