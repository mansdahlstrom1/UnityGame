using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public float speed;

    private Rigidbody2D r2d;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        r2d.velocity = new Vector2(0.0f, speed * -1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
