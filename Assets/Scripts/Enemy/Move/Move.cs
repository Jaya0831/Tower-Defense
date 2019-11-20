using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject way;
    private List<Vector3> WayPoints=new List<Vector3>();
    public float speed;
    public int index;
    public Vector3 realSpeed;
    public Vector3 upPosition;

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
        EnemyMove();
    }
    public void LoadPath(GameObject go)
    {
        foreach(Transform t in go.transform)
        {
            WayPoints.Add(t.position+upPosition);
            //Debug.Log(upPosition);
        }
    }
    private void EnemyMove()
    {
        if (Vector3.Distance(transform.position, WayPoints[index]) > 1.3)
        //if(transform.position!=WayPoints[index])
        {
            realSpeed = Vector3.MoveTowards(transform.position, WayPoints[index], speed);
            GetComponent<Rigidbody>().MovePosition(realSpeed);
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
}
