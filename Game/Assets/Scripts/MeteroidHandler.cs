using UnityEngine;
using System.Collections;

public class MeteroidHandler : MonoBehaviour
{
    private Vector3 startPosition;
    public GameObject meteroid, warningIndicator;
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
            startPosition = new Vector3(Random.Range(-1100.0f, 1100.0f), 700);
            Instantiate(meteroid, startPosition, Quaternion.identity);
            startPosition.y = 591.4f;
            Instantiate(warningIndicator, startPosition, Quaternion.identity);
        }
    }
}
