using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : Move
{
    // Start is called before the first frame update
    void Awake()
    {
        speed = 0.5f;
        upPosition = new Vector3(0, 0, 0);
    }

    
}
