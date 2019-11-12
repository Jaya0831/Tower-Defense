using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float speed;
    public int timer;
    public int timerRuler;
    public float radius;
    private Vector3 view;
    public static int price;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        GameObject target;
        Collider[] cols=Physics.OverlapSphere(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
        
        if (cols.Length != 0)
        {
            //Debug.Log("shoot");
            target = cols[0].gameObject;
            foreach (var item in cols)
            {
                if (Vector3.Distance(transform.position, item.transform.position) < Vector3.Distance(transform.position, target.transform.position))
                {
                    target = item.gameObject;
                    
                }
            }
            view = target.transform.position - transform.position;
            transform.forward = view;
            if (timer >= timerRuler)
            {
                Shoot(target);
                timer = 0;
            }
        }
        
    }
    public void Shoot(GameObject target)
    {
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().DamageAfterseconds();
        bullet.GetComponent<Bullet>().targetEnemy = target;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public static void PlaceWeapon(Vector3 vector3,GameObject gameObject)
    {
        Instantiate(gameObject, vector3, Quaternion.identity);
        
    }
}
