using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_ctrl : MonoBehaviour
{
    public Button mybutton;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);  
        // ��ư�� �̺�Ʈ �߰�
        mybutton.onClick.AddListener(ActivateObject);

    }
    void ActivateObject()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Draw"))
        //{
        //    Debug.Log("��ü����");
        //    if(state == false)
        //    {
        //        gameObject.SetActive(true);
        //        state = true;
        //    }
        //    else
        //    {
        //        gameObject.SetActive(true);
        //        Debug.Log("��ü�����");
        //        state = false;
        //    }
        //}
    }
}
