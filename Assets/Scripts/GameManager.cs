using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager, MonoBehaviour>
{
    public enum EndWay
    {
        Win,
        Loose
    }

    public string[] Scenes;

    public void LoadScene(string sceneName)
    {
        
    }
    
    
    public void GamePause()
    {
        
    }

    public void GameResume()
    {
        
    }

    public void GameStart()
    {
        
    }

    public void EndGame(EndWay endWay)
    {
        
    }
}
