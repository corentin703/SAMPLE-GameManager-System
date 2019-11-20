using System;
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

        m_listScenes = new List<string>();
        
        foreach (string scene in Scenes)
        {
            if (true)
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
        
        DontDestroyOnLoad(this);
    }

    public void LoadScene(int sceneNum)
    {
        if (sceneNum >= m_listScenes.Count)
            throw new Exception("[GameManager] Scene reference error");
        
        LoadScene(m_listScenes[sceneNum]);
        
        notifyManagers(EManagerNotif.SceneChanged);
    }
    
    public void LoadScene(string sceneName)
    {
        if (m_listScenes.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            notifyManagers(EManagerNotif.SceneChanged);
        }
        else if (m_dictEndScenes.ContainsValue(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
            throw new Exception("[GameManager] Scene reference error");
    }

    public void LoadNextScene()
    {
        if ((m_currentSceneIndex + 1) >= (m_listScenes.Count - 1))
            LoadScene(m_currentSceneIndex + 1);
        else
            EndGame(EndWay.Win);
    }

    public void GamePause()
    {
        MGR_TimeLine.Instance.ChronoPause();
    }

    public void GameResume()
    {
        MGR_TimeLine.Instance.ChronoResume();
    }

    public void GameStart()
    {
//        LoadScene(m_listScenes[0]);
        SceneManager.LoadScene(m_listScenes[0]);

        MGR_TimeLine.Instance.ChronoStart();
    }

    public void EndGame(EndWay endWay)
    {
        MGR_TimeLine.Instance.ChronoStop();
        
        LoadScene(m_dictEndScenes[endWay]);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private enum EManagerNotif
    {
        SceneChanged
    }
    private void notifyManagers(EManagerNotif managerNotif)
    {
        if (managerNotif == EManagerNotif.SceneChanged)
        {
            MGR_Gameplay.Instance.NotifySceneChanged();
            MGR_Ressource.Instance.NotifySceneChanged();
            MGR_Song.Instance.NotifySceneChanged();
            MGR_TimeLine.Instance.NotifySceneChanged();
            MGR_UI.Instance.NotifySceneChanged();
        }
        else
            throw new Exception("[GameManager] that manager notification is not implemented");
    }
}
