using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;

    private Rigidbody2D r2d;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        r2d.velocity = new Vector2(0.0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Notify GameScript todo

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
