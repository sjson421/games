﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplattest : MonoBehaviour {
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
