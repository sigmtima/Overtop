using UnityEngine;

public class Inputs : MonoBehaviour
{
    public static Vector2 mouseWorldPos;

    private void Start()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        GetMouseWorldPosition();
    }

    public void GetMouseWorldPosition()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePoint);
    }
}