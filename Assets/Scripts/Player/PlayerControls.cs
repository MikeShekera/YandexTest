using UnityEngine;

namespace TestTask.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControls : MonoBehaviour
    {
        [Range(0.01f, 0.1f)]
        [SerializeField] private float forceModifier = 1f;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                _rb.velocity += Vector2.up * forceModifier;
            }
            else
            {
                _rb.velocity -= Vector2.up * forceModifier;
            }
        }
    }
}