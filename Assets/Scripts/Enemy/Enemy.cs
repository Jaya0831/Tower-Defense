using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int blood;
    public int demageToPlayer;
    public float distance = 0;
    public int award;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance += Mathf.Pow(Mathf.Pow(GetComponent<Rigidbody>().velocity.x, 2) + Mathf.Pow(GetComponent<Rigidbody>().velocity.y, 2) + Mathf.Pow(GetComponent<Rigidbody>().velocity.z, 2), 1 / 3) * Time.deltaTime;

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

