using UnityEngine;

namespace Ressource
{
    public class InitResourceManager : MonoBehaviour
    {
        public ResourceManager.SResourceInfo[] ResourceInfos;
        private void Awake()
        {
            if (ResourceManager.Instance)
                ResourceManager.Instance.SetUp(ResourceInfos);
        
            Destroy(this);
        }
    }
}
