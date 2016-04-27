using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float speed;

    private PlayerShip myShip;
    private Rigidbody2D r2d;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(0.0f, speed);
    }

    public void Init(PlayerShip ship)
    {
        myShip = ship;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Meteroid(Clone)")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
