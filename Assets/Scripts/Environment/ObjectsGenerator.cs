using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    [SerializeField] private CoinPickup coinPrefab;
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private Transform coinHolder;
    [SerializeField] private Rigidbody2D player;

    [SerializeField] private float coinSpawnRate = 3f;
    [SerializeField] private float maxObstacleSpawnRate = 2f;

    [SerializeField] private ScoreHolder scoreHolder;

    private void Start()
    {
        StartCoroutine(nameof(SpawnCoin));
        StartCoroutine(nameof(SpawnObstacle));
    }

    private IEnumerator SpawnObstacle()
    {
        var height = Random.Range(-3, 3);
        var obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], transform);
        obstacle.transform.position = new Vector3(10, height, 0);

        StartCoroutine(DestroyEntity(obstacle.gameObject));

        var spawnTime = Random.Range(0, maxObstacleSpawnRate);
        yield return new WaitForSeconds(spawnTime);
        yield return SpawnObstacle();
    }

    private IEnumerator SpawnCoin()
    {
        var height = Random.Range(-4, 4);
        var coin = Instantiate(coinPrefab, transform);
        coin.transform.position = new Vector3(10, height, 0);
        coin.GetComponent<CoinController>().SetPlayer(player.gameObject);

        coin.CoinPickedUp.AddListener(scoreHolder.UpdateScore);
        StartCoroutine(DestroyEntity(coin.gameObject));

        yield return new WaitForSeconds(coinSpawnRate);
        yield return SpawnCoin();
    }

    private IEnumerator DestroyEntity(GameObject coin)
    {
        yield return new WaitForSeconds(5f);
        Destroy(coin);
    }
}
