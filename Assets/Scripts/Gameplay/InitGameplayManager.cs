using UnityEngine;

namespace Gameplay
{
    public class InitGameplayManager : MonoBehaviour
    {
        public GameObject Player;
        public GameplayManager.SBonus[] Bonus;
    
        void Awake()
        {
            if (GameplayManager.Instance)
                GameplayManager.Instance.SetUp(Player, Bonus);
        
            Destroy(this);
        }
    }
}
