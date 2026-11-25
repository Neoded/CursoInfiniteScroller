using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float destroyTime = 1f;
        Destroy(gameObject, destroyTime);
    }
}
