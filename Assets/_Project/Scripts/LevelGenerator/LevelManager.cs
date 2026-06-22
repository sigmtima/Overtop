using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelGenerator
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        [SerializeField] private int scenesPerSpecialScene = 3;
        [SerializeField] private int firstGameplaySceneIndex = 2;
        [SerializeField] private int specialSceneIndex = 1;
        private readonly List<int> _activeScenes = new();
        private int _loadedScenesCount;
        private readonly List<int> _originalScenes = new();
        private int _totalNumberOfScenes;
        public event System.Action OnDifficultyIncreased;

        private void Awake()
        {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            _totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;
            for (var i = firstGameplaySceneIndex; i < _totalNumberOfScenes; i++)
            {
                _originalScenes.Add(i);
                _activeScenes.Add(i);
            }
        }

        public void LoadNextScene()
        {
            Debug.Log("LoadNextScene called");
            Debug.Log($"Before check: {_loadedScenesCount}");
            if (_loadedScenesCount == scenesPerSpecialScene)
            {
                Debug.Log($"Loading {_loadedScenesCount} scenes");
                OnDifficultyIncreased?.Invoke();
                SceneManager.LoadScene(specialSceneIndex);
                _loadedScenesCount = 0;
                return;
            }

           
            if (_activeScenes.Count == 0) _activeScenes.AddRange(_originalScenes);
            
                    _loadedScenesCount++;
                    
                    var currentSceneIndex = Random.Range(0, _activeScenes.Count);
                    SceneManager.LoadScene(_activeScenes[currentSceneIndex]);
                    _activeScenes.RemoveAt(currentSceneIndex);
        }

        /*Логика рандомной генерации
         НАМ нужно записать все наши сцены в List<> или Stack<>
         Сам метод рандомной генерации
         Мы берем через Random.Ranпу(0, Лист/Стэек наших сцен.count)
         И номер этой сцены берем, и загружаем,
         потом нам нужно, вот я если честно хз как либо сделать отдельный List или Stack<> куда мы положем, эту сцену, который мы заберем из List<> наших сцен
         каждое допустим 5 срабатывание нашего метода, то есть у нас будет какая то переменная, которая будет каждое выполнение нашего метода прибалять +1
         когда это значние == 5 , мы берем из Stack сцен которых мы забирали из наших сцен мы кладем обратно в List<> или Stack наших сцен
         *
         *
         */
    }
}