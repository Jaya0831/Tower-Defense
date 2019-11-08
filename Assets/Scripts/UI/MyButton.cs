using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    
    public bool isButtonEnter;
    // Start is called before the first frame update
    void Start()
    {
        isButtonEnter = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isButtonEnter = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isButtonEnter = false;
    }
}
