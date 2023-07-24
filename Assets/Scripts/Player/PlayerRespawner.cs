using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawner : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.layer == 3 && other.gameObject.layer == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
