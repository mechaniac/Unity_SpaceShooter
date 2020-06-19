using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{

    public GameObject levelElementPrefab;

    GameObject[] levelElements;
    public Transform objectToFollow;

    int lE_Count = 3;
    int levelElementHeight = 16;

    private void Start()
    {
        InstantiateLevelElements();

    }

    void InstantiateLevelElements()
    {
        levelElements = new GameObject[lE_Count];
        for (int i = 0; i < lE_Count; i++)
        {
            var l = levelElements[i] = Instantiate(levelElementPrefab);
            l.transform.parent = transform;
            l.transform.position = transform.position + new Vector3(0, i * levelElementHeight, 0);
            
        }
    }

    void Update()
    {
        transform.position = new Vector3(0, objectToFollow.transform.position.y * 0.5f, 3);
    }
}
