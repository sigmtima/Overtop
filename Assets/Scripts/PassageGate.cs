using LevelManagement;
using UnityEngine;

public class PassageGate : MonoBehaviour
{
    [SerializeField] private GameObject blockPassageGate;

    public void OnEnable()
    {
        LevelDirector.OnLevelCleared += OpenPassage;
    }

    public void OnTriggerEnter(Collider other)
    {
        LevelManager.Instance.LoadNextScene();
    }

    //Логика портала или прохода, хз как правильно назвать
    //Вообщем все достаточно просто, нам нужно откуда то взять перменную (наверное сделать какой то скрипт, который будет считать состояния сейчас на сцене)
    // если все наши враги на сцене убиты то выключается GameObject (который блокировал проход)
    //В методе OnTriggerEnter мы просто вызываем наш синглтон LoadNextScene, впринципе тут все
    public void OpenPassage()
    {
        blockPassageGate.SetActive(true);
    }
}