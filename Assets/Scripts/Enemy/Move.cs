using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject way;
    private List<Vector3> WayPoints=new List<Vector3>();
    public float speed=1;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index=0;
        //Debug.Log(index);
        LoadPath(way);
        //Debug.Log(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, WayPoints[index]) > 1.3)
        //if(transform.position!=WayPoints[index])
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, WayPoints[index], speed);
            GetComponent<Rigidbody>().MovePosition(temp);
            //Debug.Log(Vector3.Distance(transform.position, WayPoints[index]));
        }
        else
        {
            index++;
            //Debug.Log(index);
            if (index >= WayPoints.Count)
            {
                index = 0;
            }

        }
    }
    private void LoadPath(GameObject go)
    {
        foreach(Transform t in go.transform)
        {
            WayPoints.Add(t.position);
        }
    }
}
