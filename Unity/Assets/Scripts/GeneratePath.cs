using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratePath : MonoBehaviour
{
    private List<GameObject> path;

    void Start()
    {
        path = new List<GameObject>();
        foreach (Transform position in GetComponentInChildren<Transform>())
            path.Add(position.gameObject);
    }

    private void Update()
    {
        int count = getActiveChildrenCount();
        if (count == 0 && path.Count > 0)
        {
            path.First().SetActive(true);
            path.RemoveAt(0);
        }
    }

    private int getActiveChildrenCount()
    {
        int count = 0;
        foreach (Transform position in GetComponentInChildren<Transform>())
        {
            if (position.GetChild(0).gameObject.active)
                count++;
        }
        return count;
    }
}
