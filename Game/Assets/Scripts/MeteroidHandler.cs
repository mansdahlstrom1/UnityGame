using UnityEngine;
using System.Collections;

public class MeteroidHandler : MonoBehaviour
{
<<<<<<< d6eae5f08c4d273a35f68300776a24c9d0fb54bc
    private Vector3 startPosition;
    public GameObject meteroid, warningIndicator;
=======

    private Vector3 startPosition;
    public GameObject meteroid;
>>>>>>> playable game with falling stuff you have to shoot or it kills you
    private float nextSpawn = 2.0f;
    public float spawnRate;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< d6eae5f08c4d273a35f68300776a24c9d0fb54bc
           
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            startPosition = new Vector3(Random.Range(-1100.0f, 1100.0f), 700);
            Instantiate(meteroid, startPosition, Quaternion.identity);
            startPosition.y = 591.4f;
          //  Instantiate(warningIndicator, startPosition, Quaternion.identity);
        }
        
=======
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            startPosition = new Vector3(Random.Range(-1100.0f, 1100.0f), 560);

            Instantiate(meteroid, startPosition, Quaternion.identity);
        }
>>>>>>> playable game with falling stuff you have to shoot or it kills you
    }
}
