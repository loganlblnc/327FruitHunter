using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    
    public List<Transform> pathlist = new List<Transform>();
    private void Start()
    {
        pathlist.Clear();
        foreach(Transform node in GetComponentsInChildren<Transform>())
        {
            if (transform.position != node.position && !pathlist.Contains(node))
            {
                pathlist.Add(node);
            }
        }
       
    }
     void OnDrawGizmos()
    {
        pathlist.Clear();
        foreach (Transform node in GetComponentsInChildren<Transform>())
        {
            if (transform.position != node.position && !pathlist.Contains(node))
            {
                pathlist.Add(node);
            }
            
        }
        Gizmos.color = Color.red;
        for(int i=0;i<pathlist.Count;i++)
        {
            Vector3 curr;
            Vector3 prev;
            curr = pathlist[i].position;
            if (i > 0) prev = pathlist[i - 1].position;
            else prev = pathlist[pathlist.Count - 1].position;
            Gizmos.DrawLine(prev, curr);
            Gizmos.DrawWireSphere(curr, .1f);
        }
       
    }
}
