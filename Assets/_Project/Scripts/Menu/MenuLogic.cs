using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuLogic : MonoBehaviour
    {
        [SerializeField] private GameObject howToPlayUI;
        [SerializeField] private int firstLevelIndex;

        public void StartGame()
        {
            SceneManager.LoadScene(firstLevelIndex);
        }
    
        public void QuitGame()
        {
            Application.Quit();
        }

        public void ShowHowToPlayUI()
        {
            howToPlayUI.SetActive(true);
        }

        public void HideHowToPlayUI()
        {
            howToPlayUI.SetActive(false);
        }
    }
}
