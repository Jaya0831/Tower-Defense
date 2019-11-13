using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        blood = 10;
        demageToPlayer = 1;
        award = 100;
        flyAbility = false;
    }

    
}
