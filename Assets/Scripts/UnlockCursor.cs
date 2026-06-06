using System;
using UnityEngine;
using System.Collections;

public class UnlockCursor : MonoBehaviour
{
    public void Start()
    {
        unlick();
    }

    public IEnumerator unlick()
    {
        yield return new WaitForSeconds(5.5f);
        // Делает курсор свободным
        Cursor.lockState = CursorLockMode.None;
    
        // Делает курсор видимым
        Cursor.visible = true;
    }
}
