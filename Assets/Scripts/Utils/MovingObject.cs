using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float updateTime;

    [SerializeField] private bool movingUp = true;

    private int _modifier;

    private void Start()
    {
        if(movingUp)
        {
            _modifier = 1;
        }
        else
        {
            _modifier = -1;
        }

        StartCoroutine(nameof(UpdateDirection));
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _modifier * Time.deltaTime);
    }

    private IEnumerator UpdateDirection()
    {
        yield return new WaitForSeconds(updateTime);
        _modifier *= -1;
        yield return UpdateDirection();
    }
}
