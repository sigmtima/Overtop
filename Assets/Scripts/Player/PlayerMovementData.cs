using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "MovementData", menuName = "Player")]
public class PlayerMovementData : ScriptableObject
{
    [FormerlySerializedAs("WalkSpeed")] [Header("Walking Settings")] public float walkSpeed = 4f;

    public float acceleration = 10f;
    public float deceleration = 12f;

    [Header("Physics")] public float rotationSpeed = 15f;

    public float massValue = 1f;
}