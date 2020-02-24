using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Ressource;
using Song;
using Timeline;
using UI;
using UnityEngine;

public class Preload : MonoBehaviour
{
    void Awake()
    {
        if (GameplayManager.Instance 
            && ResourceManager.Instance
            && SongManager.Instance
            && TimelineManager.Instance
            && UIManager.Instance)
            GameManager.Instance.GameStart();

        Debug.developerConsoleVisible = true;
        
        Destroy(this);
    }
}
