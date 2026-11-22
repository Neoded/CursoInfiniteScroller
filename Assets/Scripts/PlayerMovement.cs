using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float upForce;
    float yInput;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.up * yInput * upForce);
    }
}
