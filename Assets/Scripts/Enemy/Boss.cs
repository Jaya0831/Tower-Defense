using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        blood = 50;
        demageToPlayer = 5;
        award = 1000;
        flyAbility = false;
    }

    
}
