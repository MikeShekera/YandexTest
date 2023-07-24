using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CoinPickup : MonoBehaviour
{
    public UnityEvent CoinPickedUp;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            CoinPickedUp.Invoke();
            Destroy(gameObject);
        }
    }
}
