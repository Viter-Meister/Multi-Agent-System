using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratePath : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> path;
    [SerializeField]
    private int pathCount = 20;

    void Start()
    {
        path = new List<GameObject>();
        foreach (Transform position in GetComponentInChildren<Transform>())
        {
            if (path.Count < pathCount)
            {
                path.Add(position.gameObject);
            }
        }
    }

    private void Update()
    {
        int count = getActiveChildrenCount();
        if (count == 0 && path.Count > 0)
        {
            path.First().SetActive(true);
            path.RemoveAt(0);
        }
        else if (count == 0 && path.Count <= 0)
        {
            GetComponent<Timer>().StopTimer();
        }
    }

    private int getActiveChildrenCount()
    {
        int count = 0;
        foreach (Transform position in GetComponentInChildren<Transform>())
        {
            if (position.GetChild(0).gameObject.active)
            {
                count++;
            }
        }
        return count;
    }
}
