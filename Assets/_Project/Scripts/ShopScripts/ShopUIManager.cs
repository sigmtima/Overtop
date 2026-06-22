using UnityEngine;

namespace ShopScripts
{
    public class ShopUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject shopUI;
 
        public void Leave()
        {
            shopUI.SetActive(false);
        }
    }
}
