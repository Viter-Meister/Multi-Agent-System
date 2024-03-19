using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneratePoints : MonoBehaviour
{
    [SerializeField] int pointsCount = 1;

    void Start()
    {
        var children = getChildren();
        System.Random rand = new System.Random();
        for (int i = 0; i < pointsCount; i++)
        {
            int index = rand.Next(children.Count);
            children[index].gameObject.SetActive(true);
            children.RemoveAt(index);
        }
    }

    private List<GameObject> getChildren()
    {
        var children = new List<GameObject>();
        foreach (Transform position in GetComponentInChildren<Transform>())
        {
            children.Add(position.gameObject);
        }
        return children;
    }
}
