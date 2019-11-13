using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 100;
        timer = 30;
        timerRuler = 30;
        radius = 30;
        price = 300;
        shootFlyEnemy = false;
    }

    
}
