using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 5f;
    private PlayerController player;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }
    private void Update()
    {
        if (!player.GameStarted)
            return;
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}