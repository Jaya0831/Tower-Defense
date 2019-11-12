using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("23333");
        if (other.tag == "Enemy")
        {
            //Debug.Log("23333");
            Destroy(other.gameObject);
            if (other.gameObject.GetComponent<Enemy1>())
            {
                GameManager.Instance.EnemyEnter(other.gameObject.GetComponent<Enemy1>().demageToPlayer);
            }
            if (other.gameObject.GetComponent<Enemy2>())
            {
                GameManager.Instance.EnemyEnter(other.gameObject.GetComponent<Enemy2>().demageToPlayer);
            }
        }
        
    }
}
