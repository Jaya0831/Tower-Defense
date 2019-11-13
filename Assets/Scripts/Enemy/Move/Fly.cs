using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Move
{
    // Start is called before the first frame update
    void Awake()
    {
        speed = 0.3f;
        upPosition = new Vector3(0, 5, 0);
    }

    
}
