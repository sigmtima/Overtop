using UnityEngine;
using UnityEngine.Serialization;

public class PassageGate : MonoBehaviour
{
    [FormerlySerializedAs("blockPassageGate")] [SerializeField] private GameObject blockedWall;
    private LevelDirector _director;

    public void OnEnable()
    {
        _director = FindObjectOfType<LevelDirector>();
        if (_director != null)
        {
            _director.OnLevelCleared += OpenPassage;
        }
    }
    public void OnDisable()
    {
        if (_director != null)
         _director.OnLevelCleared -= OpenPassage;
    }
    //Логика портала или прохода, хз как правильно назвать
    //Вообщем все достаточно просто, нам нужно откуда то взять перменную (наверное сделать какой то скрипт, который будет считать состояния сейчас на сцене)
    // если все наши враги на сцене убиты то выключается GameObject (который блокировал проход)
    //В методе OnTriggerEnter мы просто вызываем наш синглтон LoadNextScene, впринципе тут все
    public void OpenPassage()
    {
        blockedWall.SetActive(false);
    }
}