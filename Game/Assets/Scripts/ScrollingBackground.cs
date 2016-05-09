using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour
{

    public float speed;
    public float tileSizeZ;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, tileSizeZ);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}
