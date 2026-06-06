using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverPanel;
    private ScoreManager scoreManager;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    public void GameOver()
    {
        scoreManager.SaveHighScore();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}