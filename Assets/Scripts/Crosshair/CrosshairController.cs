using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;

    [SerializeField] private float followSpeed;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //  Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 targetPos = Inputs.mouseWorldPos;
        targetPos.z = 0;
        targetPos = Vector3.Lerp(crosshair.transform.position, targetPos, followSpeed * Time.deltaTime);
        crosshair.transform.position = targetPos;
    }
}