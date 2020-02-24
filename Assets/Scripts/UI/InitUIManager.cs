using UnityEngine;

namespace UI
{
    public class InitUIManager : MonoBehaviour
    {
        // TODO: Your UI properties to define here and to pass to the MGR
        void Awake()
        {
            if (UIManager.Instance)
                UIManager.Instance.SetUp();
        
            Destroy(this);
        }
    }
}
