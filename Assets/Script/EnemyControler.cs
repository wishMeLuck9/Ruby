using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Public variables
    public float speed = 2f;
    public bool vertical;
    public float changeTime = 3.0f;

    // Private variables
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            direction = -direction;
            timer = changeTime;

            Debug.Log("Mudou direção para: " + direction);
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y += speed * direction * Time.fixedDeltaTime;
        }
        else
        {
            position.x += speed * direction * Time.fixedDeltaTime;
        }

        rigidbody2d.MovePosition(position);
    }
}