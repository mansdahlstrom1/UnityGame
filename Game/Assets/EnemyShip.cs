using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

    //public List<Vector2> missileSpawnPoints;
    public GameObject missile;
    public Transform missileSpawn;
    public float fireRate;
    public int moveSpeed;

    private Rigidbody2D r2d;
    private Vector2 velocity = new Vector2(0.0f, 0.0f);

    private Rect shipBounds;
    private Rect cameraRect;

    private float nextFire = 0.0f;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        //r2d.velocity = velocity;
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
