using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CoinController : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5;

    private Transform _player;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.left * 5;
    }

    private void Update()
    {
        if (_player == null)
            return;

        if (Vector2.Distance(transform.position, _player.position) < detectionDistance)
        {
            _rb.transform.position = Vector2.MoveTowards(_rb.transform.position, _player.position, Time.deltaTime * 3);
        }
    }

    public void SetPlayer(GameObject obj)
    {
        _player = obj.transform;
    }
}
