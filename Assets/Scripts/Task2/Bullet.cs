using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 3f; // Destroys itself so it doesn't clutter memory

    void Start()
    {
        // Destroy the bullet automatically after 3 seconds
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move forward along the X axis every frame
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}