using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            Pickup();
            gameObject.SetActive(false);
        }
    }

    public abstract void Pickup();
}