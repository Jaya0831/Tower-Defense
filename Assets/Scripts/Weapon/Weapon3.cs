using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Weapon3 : Weapon
    {
    // Start is called before the first frame update
    void Awake()
    {
        speed = 100;
        prices = new int[] { 500, 200, 250 };
        shootFlyEnemy = true;
        grade = 1;
        damageUpgrade = new int[] { 3, 4, 5 };
        cdTimeUpgrade = new int[] { 50, 40, 30 };
        radiusUpgrade = new int[] { 40, 45, 50 };
        scaleHurt = (int)radius - 15;
        scaleHurtDamage = damage / 2;
    }
        


    }


