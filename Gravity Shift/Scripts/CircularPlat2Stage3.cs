using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlat2Stage3 : MonoBehaviour {
    public GameObject platform;

    float timeCounter = 0;
    float speed;
    float width;
    float height;

    // Use this for initialization
    void Start()
    {
        speed = 1f / 2;
        width = 20;
        height = 20;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Sin(timeCounter) * height * -1;
        float y = -5;
        float z = Mathf.Cos(timeCounter) * width * -1;

        platform.transform.position = new Vector3(x, y, z +60);

    }
}
