using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CoinFollow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private const float DECREASE_TIME = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            rb.velocity = Vector2.MoveTowards(rb.transform.position, collision.gameObject.transform.position, 3);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            rb.velocity = Vector2.MoveTowards(rb.transform.position, collision.gameObject.transform.position, 3);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            StartCoroutine(nameof(DecreaseVelocity));
        }
    }

    private IEnumerator DecreaseVelocity()
    {
        float elapsedTime = 0;
        var startVelocity = rb.velocity;

        while(elapsedTime < DECREASE_TIME)
        {
            elapsedTime += Time.deltaTime;
            var progress = elapsedTime / DECREASE_TIME;

            rb.velocity = Vector3.Lerp(startVelocity, Vector3.zero, progress);

            yield return null;
        }
    }
}
