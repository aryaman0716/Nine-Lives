using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    private float startMinSpawnTime = 1.5f;
    [SerializeField]
    private float startMaxSpawnTime = 3f;
    [SerializeField]
    private float minimumSpawnTime = 1.0f;  

    private PlayerController player;
    private SpeedManager speedManager;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        speedManager = FindFirstObjectByType<SpeedManager>();
        ScheduleNextSpawn();
    }
    private float GetSpawnDelay()
    {
        // As speed increases from 5 to 20, spawn times decrease from start values to minimum values
        float speedPercent = Mathf.InverseLerp(5f, 20f, speedManager.CurrentSpeed); 
        float minTime = Mathf.Lerp(startMinSpawnTime, minimumSpawnTime, speedPercent);
        float maxTime = Mathf.Lerp(startMaxSpawnTime, minimumSpawnTime + 0.8f, speedPercent);
        return Random.Range(minTime, maxTime);
    }
    private void ScheduleNextSpawn()
    {
        float delay = GetSpawnDelay();
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