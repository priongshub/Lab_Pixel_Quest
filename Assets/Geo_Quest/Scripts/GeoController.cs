using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoController : MonoBehaviour { 
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        float playerSpeed = 5.5f;
        Debug.Log("Hello World");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }
}                                                                          