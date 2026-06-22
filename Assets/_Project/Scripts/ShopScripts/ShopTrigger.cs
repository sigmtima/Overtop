using UnityEngine;

namespace ShopScripts
{
    public class ShopTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject shopUI;
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Я ВКЛЮЧИЛСЯ");
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log(" ПЛЕЕР Я ВКЛЮЧИЛСЯ");
                shopUI.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Вышел: " + other.name);
            if (other.CompareTag("Player"))
            {
                shopUI.SetActive(false);
            }
        }
    }
}
