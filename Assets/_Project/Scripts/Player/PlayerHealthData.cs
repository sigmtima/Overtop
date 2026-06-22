using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [CreateAssetMenu(menuName = "Player/Health", fileName =  "PlayerHealthData")]
    public class PlayerHealthData : ScriptableObject
    {
        [FormerlySerializedAs("Health")] public float startMaxHealth;
    }
}
