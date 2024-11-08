 namespace Mapseur
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using UnityEngine;

    public static class OSWMap
    {
        private static HttpClient m_Client = new HttpClient();

        public static async Task GetMapSpriteOpenStreeMap(Vector2Int tile, int zoom,SpriteRenderer targetRenderer)
        {
            m_Client.DefaultRequestHeaders.Add("User-Agent", "MonApplication/1.0");
            string url = "https://tile.openstreetmap.org/" + zoom + "/" + tile.x + "/" + tile.y + ".png";
            HttpResponseMessage response = await m_Client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageBytes);

                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                targetRenderer.sprite = sprite;
            }
        }
        
        public static async Task GetMapSpriteOpenStreetMapFr(Vector2Int tile, int zoom,SpriteRenderer targetRenderer)
        {
            m_Client.DefaultRequestHeaders.Add("User-Agent", "MonApplication/1.0");
            string url = "https://a.basemaps.cartocdn.com/light_nolabels/"+ zoom + "/" + tile.x + "/" + tile.y + ".png";
            HttpResponseMessage response = await m_Client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageBytes);

                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                targetRenderer.sprite = sprite;
            }
        }
        
    }
}