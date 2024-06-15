using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private float moveSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
    transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    if (transform.position.y > 10){
        transform.position += new Vector3(0, -20f, 0);
    }

    }
}


