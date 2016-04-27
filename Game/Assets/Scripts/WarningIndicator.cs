using UnityEngine;
using System.Collections;

public class WarningIndicator : MonoBehaviour
{
    private int warnTime = 4; //seconds
    private float timer;
    // Use this for initialization
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer + warnTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
