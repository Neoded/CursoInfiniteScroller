using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TMP_Text scoreText;

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

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    public void StopGame()
    {
        Scroll[] scrolls = FindObjectsByType<Scroll>();
        foreach (var scroll in scrolls)
        {
            scroll.StopScroll();
        }

        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.StopSpawning();
    }

}
