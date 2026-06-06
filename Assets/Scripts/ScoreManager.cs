using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    private PlayerController player;
    private float score;
    private int highScore;

    public int CurrentScore => Mathf.FloorToInt(score);
    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        if (!player.GameStarted)
            return;

        score += Time.deltaTime * 10f;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
        highScoreText.text = "Best: " + highScore;
    }
    public void SaveHighScore()
    {
        if (CurrentScore > highScore)
        {
            highScore = CurrentScore;
            Debug.Log("New High Score: " + highScore);
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = "Best: " + highScore;
        }
    }
}