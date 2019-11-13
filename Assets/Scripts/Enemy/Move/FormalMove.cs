using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormalMove : Move
{
    // Start is called before the first frame update
    void Awake()
    {
        speed = 1;
        upPosition = new Vector3(0, 0, 0);
    }

    
}
