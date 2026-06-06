using UnityEngine;
[CreateAssetMenu(fileName = "MovementData", menuName = "Capcom/Player/Movement Data")]
public class PlayerMovementData : ScriptableObject
{
 
    [Header("Walking Settings")]
    public float walkSpeed = 4f;
    public float acceleration = 10f; 
    public float deceleration = 12f;

    [Header("Physics")]
    public float rotationSpeed = 15f;
    public float massValue = 1f; 
}