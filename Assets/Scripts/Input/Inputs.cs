using UnityEngine;

public class Inputs : MonoBehaviour
{

   public static  Vector2 mouseWorldPos; 

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {

        
    
    }
    void FixedUpdate()
    {
         GetMouseWorldPosition();
    }
    public void GetMouseWorldPosition()
    {
        
   
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
