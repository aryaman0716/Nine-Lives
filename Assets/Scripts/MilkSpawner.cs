using UnityEngine;

public class MilkSpawner : MonoBehaviour
{
    [SerializeField] private GameObject milkPrefab;
    [SerializeField] private float minSpawnTime = 10f;
    [SerializeField] private float maxSpawnTime = 20f;

    private PlayerController player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        ScheduleNextSpawn();
    }

    private void ScheduleNextSpawn()
    {
        float delay = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnMilk), delay);
    }

    private void SpawnMilk()
    {
        if (!player.GameStarted)
        {
            ScheduleNextSpawn();
            return;
        }

        Vector3 spawnPosition = transform.position;

        spawnPosition.y = Random.Range(0.5f, 1f);

        Instantiate(milkPrefab, spawnPosition, Quaternion.identity);
        ScheduleNextSpawn();
    }
}