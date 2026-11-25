using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject xplosionParticles;
    [SerializeField] GameObject starParticles;
    private void OnTriggerExit2D(Collider2D collision)
    
    {
        int obstaclePoints = 1;

        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.AddScore(obstaclePoints);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.StopGame();
            Instantiate(xplosionParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Star star = collision.GetComponent<Star>();
        if (star != null)
        {
            GameManager.Instance.AddScore(star.GetPoints());
            Instantiate(starParticles, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
