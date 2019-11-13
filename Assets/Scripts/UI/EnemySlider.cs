using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlider : MonoBehaviour
{
    public GameObject enemy;
    private float initialBlood;
    // Update is called once per frame
    private void Start()
    {
        //Debug.Log("233");
        initialBlood = enemy.GetComponent<Enemy>().blood;
    }
    void Update() 
    {
        
        if (enemy==null)
        {
            //Debug.Log("2333");
            Destroy(gameObject);
        }
        else
        {
            transform.position = enemy.transform.position + new Vector3(0, 5, 0);
            GetComponent<Slider>().value = (float)(enemy.GetComponent<Enemy>().blood) / initialBlood;
        }
    }
}
