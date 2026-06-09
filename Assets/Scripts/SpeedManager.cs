using UnityEngine;
public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance;

    [SerializeField] private float startSpeed = 5f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float acceleration = 0.2f;
    public float CurrentSpeed { get; private set; }
    private PlayerController player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        CurrentSpeed = startSpeed;
    }

    private void Update()
    {
        if (!player.GameStarted)
            return;

        if (CurrentSpeed < maxSpeed)
        {
            CurrentSpeed += acceleration * Time.deltaTime;
            CurrentSpeed = Mathf.Min(CurrentSpeed, maxSpeed);
        }
    }
}