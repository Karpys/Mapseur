namespace Mapseur
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class MapTileDisplayer : MonoBehaviour
    {
        [SerializeField] private MapTileViewer m_MapTileViwerPrefab = null;
        [SerializeField] private Vector2 m_Coord = Vector2.zero;
        [SerializeField] private int m_MapWidth = 0;
        [SerializeField] private int m_MapHeight = 0;
        [SerializeField] private int m_Zoom = 0;
        [SerializeField] private bool m_Delay = false;
        
        [Header("Parent")]
        [SerializeField] private Transform m_TileParent = null;

        private void Awake()
        {
            TryCreateMap();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                EraseMap();
                TryCreateMap();
            }
        }

        private void TryCreateMap()
        {
            StopCoroutine(CreateMapDelay());
            if (m_Delay)
            {
                StartCoroutine(CreateMapDelay());
            }
            else
            {
                CreateMap();
            }
        }

        //Todo:Correctly Clear or Pool System
        private void EraseMap()
        {
            for (int i = m_TileParent.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(m_TileParent.GetChild(i).gameObject);
            }
        }

        private void CreateMap()
        {
            if(m_Zoom >= 20)
                return;
            Vector2Int middleTile = m_Coord.ToTile(m_Zoom);

            for (int posX = -m_MapWidth/2,x = middleTile.x - m_MapWidth / 2; x < middleTile.x + m_MapWidth / 2; x++,posX++)
            {
                for (int posY = -m_MapHeight/2,y = middleTile.y - m_MapHeight / 2; y < middleTile.y + m_MapHeight / 2; y++,posY++)
                {
                    Vector3 newPos = new Vector3(posX, -posY, 0);
                    MapTileViewer tileViewer = Instantiate(m_MapTileViwerPrefab, newPos, Quaternion.identity, m_TileParent);
                    tileViewer.Initialize(new Vector2(x,y), false, m_Zoom);
                }
            }
        }

        private IEnumerator CreateMapDelay()
        {
            if(m_Zoom >= 20)
                yield break;
            Vector2Int middleTile = m_Coord.ToTile(m_Zoom);

            for (int posX = -m_MapWidth/2,x = middleTile.x - m_MapWidth / 2; x < middleTile.x + m_MapWidth / 2; x++,posX++)
            {
                for (int posY = -m_MapHeight/2,y = middleTile.y - m_MapHeight / 2; y < middleTile.y + m_MapHeight / 2; y++,posY++)
                {
                    Vector3 newPos = new Vector3(posX, -posY, 0);
                    MapTileViewer tileViewer = Instantiate(m_MapTileViwerPrefab, newPos, Quaternion.identity, m_TileParent);
                    tileViewer.Initialize(new Vector2(x,y), false, m_Zoom);
                    yield return null;
                }
            }
        }
    }
}