using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTray : MonoBehaviour
{
    [SerializeField] private GameObject trayPrefab;
    [SerializeField] private Transform spawnTransform;

    [Range(0.2f, 2)]
    [SerializeField] private float trayFadeTimer = 1f;

    private const float TARGET_SCALE = 0.2f;

    private void FixedUpdate()
    {
        var tray = Instantiate(trayPrefab, spawnTransform);
        tray.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
        StartCoroutine(TrayFade(tray));
    }

    private IEnumerator TrayFade(GameObject trayElement)
    {
        var image = trayElement.GetComponent<SpriteRenderer>();
        float lifeTime = 0;
        Vector3 targetScale = new Vector3(TARGET_SCALE, TARGET_SCALE, TARGET_SCALE);

        while(lifeTime < trayFadeTimer)
        {
            lifeTime += Time.deltaTime;
            var progress = lifeTime / trayFadeTimer;

            trayElement.transform.localScale = Vector3.LerpUnclamped(Vector3.one, targetScale, progress);

            var tempColor = image.color;
            tempColor.a = Mathf.Lerp(1, 0, progress);
            image.color = tempColor;

            yield return null;
        }

        Destroy(trayElement);
    }
}
