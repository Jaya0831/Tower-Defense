using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeButton : MonoBehaviour
{
    public GameObject weaponToBeUpGrade;
    private Button upGradeButton;
    // Start is called before the first frame update
    void Start()
    {
        upGradeButton = this.GetComponent<Button>();
        upGradeButton.onClick.AddListener(
            delegate ()
            {
                weaponToBeUpGrade.GetComponent<Weapon>().UpGrade();
            }
            );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
