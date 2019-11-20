using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public GameObject weaponUI;
    public Camera minecamera;
    public GameObject weaponPrefab;
    private GameObject block;
    private Vector3 blockPosition;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject upGradeUI;
    public Text hurtText;
    public Text radiusText;
    public Text cdText;
    public Button upGradeButton;
    public GameObject ownerOfUpGradeUI;
    public int[] price;
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
            if (upGradeButton.GetComponent<MyButton>().isButtonEnter==false&&button1.GetComponent<MyButton>().isButtonEnter==false&& button2.GetComponent<MyButton>().isButtonEnter == false&& button3.GetComponent<MyButton>().isButtonEnter == false)
            {//是这里button的进入判定出问题了吗

                //这里就debug不出来
                //Debug.Log("2222");
                if (Physics.Raycast(ray, out raycastHit, 1000, 1 << LayerMask.NameToLayer("Map")))
                {
                    //Debug.Log(Physics.Raycast(ray, out raycastHit, 1 << LayerMask.NameToLayer("Map")));
                    blockPosition = raycastHit.transform.position;
                    block = raycastHit.collider.gameObject;
                    upGradeUI.SetActive(false);
                    if(block.GetComponent<Block>().isEmpty == true)
                    {
                        if (weaponUI.active == false)
                        {
                            weaponUI.transform.SetPositionAndRotation(minecamera.WorldToScreenPoint(raycastHit.transform.position) + new Vector3(0, 60, 0), Quaternion.identity);
                            weaponUI.SetActive(true);
                            upGradeUI.SetActive(false);
                            //Debug.Log("2222");
                        }
                        else
                        {
                            weaponUI.SetActive(false);
                            weaponUI.transform.SetPositionAndRotation(minecamera.WorldToScreenPoint(raycastHit.transform.position) + new Vector3(0, 60, 0), Quaternion.identity);
                            weaponUI.SetActive(true);
                        }
                    }
                    else
                    {
                        upGradeUI.transform.SetPositionAndRotation(minecamera.WorldToScreenPoint(raycastHit.transform.position) + new Vector3(0, 60, 0), Quaternion.identity);
                        upGradeUI.SetActive(true);
                        weaponUI.SetActive(false);
                        ownerOfUpGradeUI = block.GetComponent<Block>().weaponObove;
                    }
                                
                }
                else 
                {
                    weaponUI.SetActive(false);
                    upGradeUI.SetActive(false);
                    if (Physics.Raycast(ray, out raycastHit, 1000, 1 << LayerMask.NameToLayer("Weapon")))
                    {
                        ownerOfUpGradeUI = raycastHit.collider.gameObject;
                        upGradeUI.transform.SetPositionAndRotation(minecamera.WorldToScreenPoint(raycastHit.transform.position) + new Vector3(0, 60, 0), Quaternion.identity);
                        upGradeUI.SetActive(true);
                        
                    }
                }
            }
            
        }
        //在update里面
        /*if (weaponUI.active == true)
        {
            //Debug.Log("2333");
            if (!block.GetComponent<Block>().isEmpty)
            {
                weaponUI.SetActive(false);
                //block = null;
               
            }
        }*/

        if (upGradeUI.active == true)
        {
            if (ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade == 3)
            {
                upGradeButton.interactable = false;
                hurtText.text = "Hurt:" + ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.damageUpgrade[ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade - 1];
                radiusText.text = "Radius:" + ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.radiusUpgrade[ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade - 1];
                cdText.text = "CDTime:" + ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.cdTimeUpgrade[ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade - 1];
            }
            else
            {
                upGradeButton.interactable = true;
                upGradeButton.GetComponent<UpGradeButton>().weaponToBeUpGrade = ownerOfUpGradeUI;
                hurtText.text = "Hurt:" + ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.damageUpgrade[ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade - 1] + " to " + ownerOfUpGradeUI.GetComponent<Weapon>().damageUpgrade[ownerOfUpGradeUI.GetComponent<Weapon>().grade];
                radiusText.text = "Radius:" + ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.radiusUpgrade[ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade - 1] + " to " + ownerOfUpGradeUI.GetComponent<Weapon>().radiusUpgrade[ownerOfUpGradeUI.GetComponent<Weapon>().grade];
                cdText.text = "CDTime:" + ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.cdTimeUpgrade[ownerOfUpGradeUI.GetComponent<WeaponController>().weaponType.grade - 1] + " to " + ownerOfUpGradeUI.GetComponent<Weapon>().cdTimeUpgrade[ownerOfUpGradeUI.GetComponent<Weapon>().grade];

            }
        }


    }
    private void CreateWeapon(int price_,int index)
    {
        
        if (GameManager.Instance.money >= price_)
        {
            //Debug.Log(weapon1Prefab.name);
            block.GetComponent<Block>().isEmpty = false;
            block.GetComponent<Block>().weaponObove = Weapon.PlaceWeapon(blockPosition + new Vector3(0, 1.5f, 0), weaponPrefab, index);
            //Debug.Log(block.GetComponent<Block>().weaponObove);
            weaponUI.SetActive(false);
            button1.GetComponent<MyButton>().isButtonEnter = false;
            button2.GetComponent<MyButton>().isButtonEnter = false;
            button3.GetComponent<MyButton>().isButtonEnter = false;
        }
    }

    public void CreateAfterClick(int buttonIndex)
    {
        CreateWeapon(price[buttonIndex], buttonIndex);
        //weaponUI.SetActive(false);
    }
    
    


}
