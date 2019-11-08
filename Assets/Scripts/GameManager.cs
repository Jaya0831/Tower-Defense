using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject enemyPrefab;
    public GameObject start;
    public int blood=10;
    public int money = 1000;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator CreateEnemy()
    {
        for (int i = 1; i < 10; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, start.transform.position, transform.rotation);
            yield return new WaitForSeconds(4f);
        }
        

    }
    public void EnemyEnter(int damage)
    {
        blood -= damage;
    }
}
