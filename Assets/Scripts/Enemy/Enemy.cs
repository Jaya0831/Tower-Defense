using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int blood;
    public int demageToPlayer;
    public float distance = 0;
    public int award;
    public bool flyAbility;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<Rigidbody>().velocity);
        distance += GetComponent<Move>().realSpeed.magnitude * Time.deltaTime;
        //Debug.Log(transform.position);
    }
    public void GetHurt(int damage)
    {
        blood -= damage;
        if (blood <= 0) 
        {
            Destroy(gameObject);
            GameManager.Instance.money += award;
            GameManager.Instance.damageCount++;
        }

    }
}

