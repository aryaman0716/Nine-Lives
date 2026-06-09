using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    private PlayerController player;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }
    private void Update()
    {
        if (!player.GameStarted)
            return;
        transform.position += Vector3.left * SpeedManager.Instance.CurrentSpeed * Time.deltaTime;
    }
}