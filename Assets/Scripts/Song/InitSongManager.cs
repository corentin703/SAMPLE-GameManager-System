using UnityEngine;

namespace Song
{
    public class InitSongManager : MonoBehaviour
    {
        public AudioClip[] BackgroundSongs;
        public SongManager.SSong[] Songs;
    
        void Awake()
        {
            if (SongManager.Instance)
                SongManager.Instance.SetUp(Songs, BackgroundSongs);
        
            Destroy(this);
        }
    }
}
