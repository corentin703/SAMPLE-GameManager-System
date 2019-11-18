﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum EndWay
    {
        Win,
        Loose
    }

    [System.Serializable]
    public struct SEndScene
    {
        public EndWay Case;
        public string SceneName;
    }
    
    [SerializeField] private string[] Scenes;
    [SerializeField] private SEndScene[] EndScenes;

    private int m_currentSceneIndex;
    private List<string> m_listScenes;
    private Dictionary<EndWay, string> m_dictEndScenes;


    protected override void Awake()
    {
        base.Awake();

        foreach (string scene in Scenes)
        {
            if (SceneManager.GetSceneByName(scene).IsValid())
            {
                m_listScenes.Add(scene);
            }
            else
                throw new Exception("[GameManager] Scene \"" + scene + "\" doen't exists");
        }

        m_dictEndScenes = new Dictionary<EndWay, string>();
        foreach (SEndScene scene in EndScenes)
        {
            if (SceneManager.GetSceneByName(scene.SceneName).IsValid())
            {
                if (m_dictEndScenes.ContainsKey(scene.Case))
                    throw new Exception("[GameManager] You can't assign more than one scene to a end game event");
                    
                m_dictEndScenes.Add(scene.Case, scene.SceneName);
            }
            else
                throw new Exception("[GameManager] Scene \"" + scene + "\" doen't exists");
        }
    }
    
    public void LoadScene(int sceneNum)
    {
        if (sceneNum >= m_listScenes.Count)
            throw new Exception("[GameManager] Scene reference error");
        
        LoadScene(m_listScenes[sceneNum]);
    }
    
    public void LoadScene(string sceneName)
    {
        if (m_listScenes.Contains(name))
            SceneManager.LoadScene(name);
        else
            throw new Exception("[GameManager] Scene reference error");
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
