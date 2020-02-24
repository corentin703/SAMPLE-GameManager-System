using UnityEngine;

namespace UI
{
    public class StartMenuInteractions : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.GameStart();
        }
    }
}
