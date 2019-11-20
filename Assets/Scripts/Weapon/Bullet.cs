using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageToEnemy;
    public GameObject targetEnemy;
    public int scaleHurt;
    public int scaleHurtDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletTrack();
    }
    public void DamageAfterseconds()
    {
        StartCoroutine(Damage());
    }
    IEnumerator Damage()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            if (other.gameObject.GetComponent<Enemy1>())
            {
                other.gameObject.GetComponent<Enemy1>().GetHurt(damageToEnemy);
            }
            if (other.gameObject.GetComponent<Enemy2>())
            {
                other.gameObject.GetComponent<Enemy2>().GetHurt(damageToEnemy);
            }
            if (scaleHurt!=0)
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, scaleHurt, 1 << LayerMask.NameToLayer("Enemy"));
                if (cols.Length != 0)
                {
                    foreach(var item in cols)
                    {
                        if (item.gameObject != other.gameObject)
                        {
                            int i = 1;
                            Debug.Log(i);
                            item.GetComponent<Enemy>().GetHurt(scaleHurtDamage);
                            i++;
                        }
                    }
                }
            }
        }
    }
    private void BulletTrack()
    {
        if (targetEnemy != null)
        {
            float velocityMagnitude = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            gameObject.GetComponent<Rigidbody>().velocity = (targetEnemy.transform.position - transform.position).normalized * velocityMagnitude;
            //Debug.Log(targetEnemy.transform.position);

        }
    }
}
