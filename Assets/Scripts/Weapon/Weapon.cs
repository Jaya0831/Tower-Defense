using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float speed;
    private GameObject target;
    public int timer;
    public int timerRuler;
    public float radius;
    public int damage;
    private Vector3 view;
    public int price;
    public bool isLocked;
    public bool shootFlyEnemy;
    public int grade;
    public int[] radiusUpgrade;
    public int[] cdTimeUpgrade;
    public int[] damageUpgrade;
    public int[] prices;
    public int scaleHurt;
    public int scaleHurtDamage;

    // Start is called before the first frame update
    void Start()
    {
        isLocked = false;
        price = prices[0];
        timer = cdTimeUpgrade[0];
        timerRuler = cdTimeUpgrade[0];
        radius = radiusUpgrade[0];
        damage = damageUpgrade[0];
        GameManager.Instance.money -= price;

    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        
        if (GameManager.Instance.selectedTarget)
        {
            if(GameManager.Instance.selectedTarget.GetComponent<Enemy>().flyAbility&&shootFlyEnemy==true|| GameManager.Instance.selectedTarget.GetComponent<Enemy>().flyAbility==false)
            {
                if (Vector3.Distance(transform.position, GameManager.Instance.selectedTarget.transform.position) <= radius)
                {
                    isLocked = true;
                    target = GameManager.Instance.selectedTarget;
                }
            }
        }
        if (!isLocked)
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
            if (shootFlyEnemy == false)
            {
                for(int i=0;i<cols.Length;i++)
                {
                    if (cols[i].gameObject.GetComponent<Enemy>().flyAbility)
                    {
                        cols[i] = null;
                    }
                }
            }
            List<Collider> availableCols=new List<Collider>();
            foreach(var item in cols)
            {
                if (item)
                {
                    availableCols.Add(item);
                }
            }
            if (availableCols.Count!=0 )
            {
                //Debug.Log("shoot");
                target = availableCols[0].gameObject;
                foreach (var item in availableCols)
                {
                    //Debug.Log(item.GetComponent<Enemy>().distance);
                    if (target.GetComponent<Enemy>().distance<item.GetComponent<Enemy>().distance)
                    {
                        target = item.gameObject;
                        //Debug.Log(target);
                    }
                }
            }
        }
        
        if (!target || Vector3.Distance(target.transform.position, transform.position) > radius)
        {
            isLocked = false;
            target = null;
        }
        else
        {
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
        bullet.GetComponent<Bullet>().damageToEnemy = damage;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().DamageAfterseconds();
        bullet.GetComponent<Bullet>().targetEnemy = target;
        bullet.GetComponent<Bullet>().scaleHurt = scaleHurt;
        bullet.GetComponent<Bullet>().scaleHurtDamage = scaleHurtDamage;
        //Debug.Log(price);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public static GameObject PlaceWeapon(Vector3 vector3,GameObject gameObject)
    {
        return Instantiate(gameObject, vector3, Quaternion.identity);
        
    }
    public void UpGrade()
    {
        if (GameManager.Instance.money >= prices[grade])
        {
            GameManager.Instance.money -= prices[grade];
            grade++;
            timer = cdTimeUpgrade[grade - 1];
            timerRuler = cdTimeUpgrade[grade - 1];
            radius = radiusUpgrade[grade - 1];
            damage = damageUpgrade[grade - 1];
        }
        
    }
}
