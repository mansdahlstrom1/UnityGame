﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BringToFront : MonoBehaviour
{

    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}