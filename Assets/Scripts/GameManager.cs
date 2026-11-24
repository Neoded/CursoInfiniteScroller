using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isGameOver = false;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    public void StopGame()
    {
        StopScrolls();
        StopSpawner();

        GameOver();
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    private static void StopSpawner() 
    {
        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.StopSpawning();
    }

    private static void StopScrolls()
    {
        Scroll[] scrolls = FindObjectsByType<Scroll>();
        foreach (var scroll in scrolls)
        {
            scroll.StopScroll();
        }
    }
}
