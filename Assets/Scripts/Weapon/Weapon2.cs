using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Weapon2 : Weapon
    {
        // Start is called before the first frame update
        void Awake()
        {
            speed = 120;
            prices = new int[] { 400, 150, 250 };
            shootFlyEnemy = true;
            grade = 1;
            damageUpgrade = new int[] { 2, 3, 4 };
            cdTimeUpgrade = new int[] { 40, 35, 30 };
            radiusUpgrade = new int[] { 35, 40, 45 };
            scaleHurt = (int)radius-15;
            scaleHurtDamage = damage / 2;
        }


    }


