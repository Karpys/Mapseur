namespace Mapseur
{
    using System;
    using UnityEngine;

    public static class MapUtils
    {
        public static Vector2Int ToTile(this Vector2 coord, int zoom)
        {
            int xTile = (int)((coord.y + 180.0) / 360.0 * (1 << zoom));
            int yTile = (int)((1.0 - Math.Log(Math.Tan(coord.x * Math.PI / 180.0) + 1.0 / Math.Cos(coord.x * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return new Vector2Int(xTile, yTile);
        }
    }
}
