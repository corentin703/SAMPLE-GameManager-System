using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_MGR_Gameplay : MonoBehaviour
{
    public GameObject Player;
    public MGR_Gameplay.SBonus[] Bonus;
    
    void Awake()
    {
        MGR_Gameplay.Instance.SetUp(Player, Bonus);
        
        Destroy(this);
    }
}
