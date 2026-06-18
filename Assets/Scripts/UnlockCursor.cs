using System.Collections;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    public void Start()
    {
        unlick();
    }

    public IEnumerator unlick()
    {
        yield return new WaitForSeconds(2f);
        // Делает курсор свободным
        Cursor.lockState = CursorLockMode.None;

        // Делает курсор видимым
        Cursor.visible = true;
    }
}