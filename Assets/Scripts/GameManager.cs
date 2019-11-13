using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject bossPrefab;
    public GameObject start;
    public int blood=10;
    public int money = 300;
    public Text moneyText;
    public Text bloodText;
    public int damageCount=0;
    private int time=0;
    public GameObject selectedTarget;
    public Camera minecamera_;
    public Slider myslider;
    public Canvas worldCanvas;
 
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        StartCoroutine(CreateEnemy(enemyPrefab1, 3, 1f));
        

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + money;
        bloodText.text = "Blood: " + blood;
        while (damageCount == 3&&time==0)
        {
            time++;
            //Debug.Log("next");
            StartCoroutine(CreateEnemy(enemyPrefab2, 3, 3f));
            break;
        }
        while (damageCount == 6&&time==1)
        {
            time++;
            StartCoroutine(CreateEnemy(bossPrefab, 1, 1f));
            break;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            ray = new Ray(minecamera_.transform.position, minecamera_.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, minecamera_.farClipPlane)) - minecamera_.transform.position);
            RaycastHit raycastHit;
            //Debug.Log("23333");
            if (Physics.Raycast(ray, out raycastHit, 1000, 1 << LayerMask.NameToLayer("Enemy")))
            {
                selectedTarget = raycastHit.collider.gameObject;
                //Debug.Log(raycastHit.collider.gameObject);
            }
        }
    }
    IEnumerator CreateEnemy(GameObject enemytype,int n,float intervalTime)
    {
        for (int i = 1; i <= n; i++)
        {
            GameObject enemy = Instantiate(enemytype, start.transform.position, transform.rotation);
            Slider enemyslider = Instantiate(myslider,enemy.transform.position+new Vector3(0,5,0),Quaternion.identity,worldCanvas.transform);
            enemyslider.GetComponent<EnemySlider>().enemy = enemy;
            yield return new WaitForSeconds(intervalTime);
        }
        

    }
    
    public void EnemyEnter(int damage)
    {
        blood -= damage;
        damageCount++;
    }
}
