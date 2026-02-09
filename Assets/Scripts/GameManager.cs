using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    [SerializeField] private BirdController player;
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private ParallaxScroller[] parallaxLayers;
    [SerializeField] private int score;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private bool isGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        UpdateScore(0);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver)
        {
            return;
        }

        UpdateScore(score + amount);
    }

    private void UpdateScore(int newScore)
    {
        score = newScore;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void OnPlayerDeath()
    {
        isGameOver = true;
        if (pipeSpawner != null)
        {
            pipeSpawner.enabled = false;
        }

        if (parallaxLayers != null)
        {
            foreach (ParallaxScroller layer in parallaxLayers)
            {
                layer.enabled = false;
            }
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
