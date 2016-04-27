using UnityEngine;
using System.Collections;

public class WarningIndicator : MonoBehaviour
{
    private int warnTime = 4; //seconds
    private float startTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + warnTime < Time.time)
        {
            
        }
    }
}
