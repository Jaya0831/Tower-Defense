﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        blood = 20;
        demageToPlayer = 2;
        award = 250;
        flyAbility = true;
    }

    
}
