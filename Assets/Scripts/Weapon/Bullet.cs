using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageToEnemy;
    public GameObject targetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy != null)
        {
            float velocityMagnitude = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            gameObject.GetComponent<Rigidbody>().velocity = (targetEnemy.transform.position - transform.position).normalized * velocityMagnitude;
            //Debug.Log(targetEnemy.transform.position);

        }

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

        }
    }
}
