using Ressource;
using UnityEngine;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
        public bool IsSetUp { get; private set; } = false;

        public void SetUp()
        {
            IsSetUp = true;
        }
    
        public void Notify(GameManager.EManagerNotif managerNotif)
        {
            if (managerNotif == GameManager.EManagerNotif.SceneChanged)
                IsSetUp = false;
        }
    
        // TODO: Define your UI's fonctions here 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("[" + GetType().Name + "] Inventory listing:");
                foreach (var VARIABLE in ResourceManager.Instance.Resources)
                {
                    Debug.Log("Name: " + VARIABLE.Name);
                    Debug.Log("Description: " + VARIABLE.Description);
                    Debug.Log("Next");
                }
        
                Debug.Log("End");
            }
        }
    }
}
