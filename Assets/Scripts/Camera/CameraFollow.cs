using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;

    Vector3 offset = new Vector3(0, 3, -10);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toFollow != null)
        {
            Vector3 verticalFollow = new Vector3(0, toFollow.transform.position.y, 0);
            transform.position = verticalFollow + offset;
        }
        
    }
}
