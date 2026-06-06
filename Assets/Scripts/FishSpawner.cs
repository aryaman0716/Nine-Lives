using UnityEngine;
public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;

    [SerializeField] private float minSpawnTime = 4f;
    [SerializeField] private float maxSpawnTime = 8f;
    private PlayerController player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        ScheduleNextSpawn();
    }

    private void ScheduleNextSpawn()
    {
        float delay = Random.Range(minSpawnTime, maxSpawnTime);

        Invoke(nameof(SpawnFish), delay);
    }

    private void SpawnFish()
    {
        if (!player.GameStarted)
        {
            ScheduleNextSpawn();
            return;
        }

        Vector3 spawnPosition = transform.position;
        spawnPosition.y = Random.Range(0.5f, 1f);
        Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
        ScheduleNextSpawn();
    }
}