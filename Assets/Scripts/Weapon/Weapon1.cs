using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : Weapon
{
    // Start is called before the first frame update
    void Awake()
    {
        speed = 100;
        prices = new int[] { 300, 100, 200 };
        shootFlyEnemy = false;
        grade = 1;
        damageUpgrade = new int[] { 1, 2, 3 };
        cdTimeUpgrade = new int[] { 30, 25, 20 };
        radiusUpgrade = new int[] { 30, 35, 40 };
        scaleHurt = 0;
        
    }

    
}
