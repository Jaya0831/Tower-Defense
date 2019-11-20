using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Weapon[] weaponTypes;
    public Weapon weaponType;
    public void  WeaponInit(int i)
    {
        weaponType = weaponTypes[i];
        weaponType.WeaponAwake();
        this.GetComponent<MeshRenderer>().material = weaponType.materialOfWeapon;
        weaponType.WeaponStart();
    }
    public void Update()
    {
        weaponType.WeaponUpdate();
    }
    
}
