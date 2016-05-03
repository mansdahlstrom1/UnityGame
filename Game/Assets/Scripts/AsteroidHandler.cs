using UnityEngine;
using System.Collections;

public class AsteroidHandler : MonoBehaviour
{
    private Vector3 startPosition;
    public GameObject asteroid;

    private float nextSpawn = 2.0f;
    public float spawnRate;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            startPosition = new Vector3(Random.Range(-700.0f, 700.0f), 650);
            Instantiate(asteroid, startPosition, Quaternion.identity);
        }
    }
}
