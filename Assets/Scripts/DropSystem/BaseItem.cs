using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
            gameObject.SetActive(false);
        }
    }

    public abstract void Pickup();
}