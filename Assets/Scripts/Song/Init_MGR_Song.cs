using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_MGR_Song : MonoBehaviour
{
    void Awake()
    {
        MGR_Song.Instance.SetUp();
        
        Destroy(this);
    }
}
