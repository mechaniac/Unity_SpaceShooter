using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    PositionBroadcast playerPos;
    public GameObject levelElement;


    GameObject[] levelElements;
    int lowestLevelElementIndex = 0;
    int levelElementsOffset = 16;
    int numberOfElements = 3;

    private void Start()
    {
        levelElements = new GameObject[numberOfElements];
        InitializeLevelElements();


        playerPos = FindObjectOfType<PositionBroadcast>();
        PositionBroadcast.PositionYUpdated += SetLevelElementPosition;
    }

    void InitializeLevelElements()
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            levelElements[i] = Instantiate(levelElement);
            levelElements[i].transform.position = transform.position + new Vector3(0, levelElementsOffset * i, 0);
            levelElements[i].transform.parent = transform;
        }
    }

    void SetLevelElementPosition()
    {
        Vector3 currentPosition = levelElements[lowestLevelElementIndex].transform.position;
        Vector3 newPosition = currentPosition + new Vector3(0, levelElementsOffset * numberOfElements, 0);
        levelElements[lowestLevelElementIndex].transform.position = newPosition;
        Debug.Log("i am at: " + newPosition.y);
        SetLowestLevelElement();
    }

    void SetLowestLevelElement()
    {
        if (lowestLevelElementIndex >= levelElements.Length - 1)
        {
            lowestLevelElementIndex = 0;
        }
        else
        {
            lowestLevelElementIndex++;
        }
    }

}
