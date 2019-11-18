using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_Ressource : Singleton<MGR_Ressource>
{
    [System.Serializable]
    public struct SRessourceInfo
    {
        private string Name;
        private string Description;

        public SRessourceInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    
    public bool IsSettingUp { get; private set; } = false;
    
    private List<ARessource> m_ressources;
    private Dictionary<string, SRessourceInfo> m_dictRessourceInfos;

    private readonly SRessourceInfo _defaultRessourceInfo = new SRessourceInfo("Default", "Default");
    
    public void SetUp(SRessourceInfo[] ressourceInfos)
    {
        IsSettingUp = true;
    }

    public bool IsBelonged(ARessource ressource)
    {
        return (m_ressources.Contains(ressource));
    }

    public void AddItem(ARessource ressource)
    {
        if (IsBelonged(ressource))
            ressource.Add(ressource.UnitNumber);
        else
            m_ressources.Add(ressource);
    }

    public void RemoveItem(ARessource ressource)
    {
        if (IsBelonged(ressource))
            m_ressources.Remove(ressource);
        else
            Debug.LogError("[MGR_Ressource] Trying to remove an non belonged object");
    }

    public SRessourceInfo GetRessourceInfos(ARessource ressource)
    {
        if (!IsSettingUp)
            throw new Exception("[MGR_Ressource] Manager not set up correctly");

        if (m_dictRessourceInfos.ContainsKey(ressource.UniqueIdentifier))
            return m_dictRessourceInfos[ressource.UniqueIdentifier];
        
        Debug.LogWarning("[MGR_Ressource] Corresponding ressource didn't found: returning default informations");
        return _defaultRessourceInfo;
    }
    
}
