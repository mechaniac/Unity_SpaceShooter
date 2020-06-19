using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBroadcast : MonoBehaviour
{
    public delegate void PositionSender();
    public static event PositionSender PositionYUpdated;

    float currentYPosition;
    readonly int broadcastStep = 16;

    void Start()
    {
        currentYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
            if(transform.position.y > currentYPosition + broadcastStep)
        {
            Debug.Log("i moved 8 up: " + transform.position.y);
            PositionYUpdated?.Invoke();
            currentYPosition = currentYPosition + broadcastStep;
        }
    }
}
