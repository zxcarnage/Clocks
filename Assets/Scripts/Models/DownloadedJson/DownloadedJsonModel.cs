using System;
using ModestTree;

namespace Models.DownloadedJson
{
    public class DownloadedJsonModel
    {
        public string Json { get; private set; }

        public event Action NewDataDownloaded;
        
        public void SetJson(string json)
        {
            if(json.IsEmpty())
                return;
            Json = json;
            NewDataDownloaded?.Invoke();
        }
    }
}