using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            mainController.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
