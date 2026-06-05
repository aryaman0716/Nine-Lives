using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private float minSpawnTime = 1.5f;

    [SerializeField]
    private float maxSpawnTime = 3f;

    private PlayerController player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        ScheduleNextSpawn();
    }
    private void ScheduleNextSpawn()
    {
        float delay = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnObstacle), delay);
    }

    private void SpawnObstacle()
    {
        if (!player.GameStarted)
        {
            ScheduleNextSpawn();
            return;
        }

        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIndex], transform.position, Quaternion.identity);

        ScheduleNextSpawn();
    }
}