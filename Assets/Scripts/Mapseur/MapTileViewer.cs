namespace Mapseur
{
    using UnityEngine;


    public class MapTileViewer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_Sprite = null;
        [SerializeField] private int m_Zoom = 0;
        [SerializeField] private bool m_UseCoord = true;
        [SerializeField] private Vector2 m_Coord = Vector2.zero;

        public void Initialize(Vector2 coord,bool useCoord,int zoom)
        {
            m_Coord = coord;
            m_UseCoord = useCoord;
            m_Zoom = zoom;
            DisplayMapTile();
        }

        private void DisplayMapTile()
        {
            OSWMap.GetMapSpriteOpenStreetMapFr(m_UseCoord ? m_Coord.ToTile(m_Zoom) : new Vector2Int((int)m_Coord.x, (int)m_Coord.y), m_Zoom, m_Sprite);
        }
    }
}