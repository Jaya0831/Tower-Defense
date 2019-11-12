using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public GameObject weaponUI;
    public Camera minecamera;
    public GameObject weapon1Prefab;
    public GameObject weapon2Prefab;
    public GameObject weapon3Prefab;
    private GameObject block;
    private Vector3 blockPosition;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            //Debug.Log("22222");
            Ray ray;
            RaycastHit raycastHit;
            ray=new Ray(minecamera.transform.position, minecamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, minecamera.farClipPlane)) - minecamera.transform.position);
            if (button1.GetComponent<MyButton>().isButtonEnter==false&& button2.GetComponent<MyButton>().isButtonEnter == false&& button3.GetComponent<MyButton>().isButtonEnter == false)
            {
                if (Physics.Raycast(ray, out raycastHit, 1000, 1 << LayerMask.NameToLayer("Map")))
                {
                    //Debug.Log(Physics.Raycast(ray, out raycastHit, 1 << LayerMask.NameToLayer("Map")));
                    blockPosition = raycastHit.transform.position;
                    block = raycastHit.collider.gameObject;
             
                    if (Vector3.Distance(weaponUI.transform.position, minecamera.WorldToScreenPoint(raycastHit.transform.position) + new Vector3(0, 60, 0)) <= 10&&weaponUI.active==true)
                    {

                        weaponUI.SetActive(false);
                        //Debug.Log("2222");
                    }
                    else
                    {
                        weaponUI.transform.SetPositionAndRotation(minecamera.WorldToScreenPoint(raycastHit.transform.position) + new Vector3(0, 60, 0), Quaternion.identity);
                        //Debug.Log(weaponUI.transform.position);
                        //Debug.Log(minecamera.WorldToScreenPoint(raycastHit.transform.position));
                        weaponUI.SetActive(true);
                    }

                }
                else
                {
                    weaponUI.SetActive(false);
                }
            }
            
            
        }


        
    }
    public void CreateAfterClick1()
    {
        //Debug.Log("CreateAfterClick1");
        if(block.GetComponent<Block>().isEmpty==false||GameManager.Instance.money>=Weapon1.price){
            Weapon.PlaceWeapon(blockPosition + new Vector3(0, 1.5f, 0), weapon1Prefab);
            //Debug.Log(weapon1Prefab.name);
            block.GetComponent<Block>().isEmpty = true;
            GameManager.Instance.money -= Weapon1.price;
        }

    }
    public void CreateAfterClick2()
    {
        //Debug.Log("CreateAfterClick2");
        if (block.GetComponent<Block>().isEmpty == false||GameManager.Instance.money>=Weapon2.price)
        {
            Weapon.PlaceWeapon(blockPosition + new Vector3(0, 1.5f, 0), weapon2Prefab);
            //Debug.Log(weapon2Prefab.name);
            block.GetComponent<Block>().isEmpty = true;
            GameManager.Instance.money -= Weapon1.price;
        }

    }
    public void CreateAfterClick3()
    {
        //Debug.Log("CreateAfterClick3");
        if (block.GetComponent<Block>().isEmpty == false)
        {
            Weapon.PlaceWeapon(blockPosition + new Vector3(0, 1.5f, 0), weapon3Prefab);
            //Debug.Log(weapon3Prefab.name);
            block.GetComponent<Block>().isEmpty = true;
            GameManager.Instance.money -= Weapon1.price;
        }

    }

}
