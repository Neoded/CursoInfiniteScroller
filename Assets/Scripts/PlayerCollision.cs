using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        int obstaclePoints = 1;

        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.AddScore(obstaclePoints);
        }
    }
    private void OnCollisionEnter2D()
    {
        GameManager.Instance.StopGame();
        Destroy(gameObject);
    }
}
