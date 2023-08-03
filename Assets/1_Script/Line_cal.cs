using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Line_cal : MonoBehaviour
{
    Button btn;
    LineRenderer lr;
    RaycastHit hits;

    
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RayCheck();
    }

    void RayCheck()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //10m 길이의 ray를 발사해서 충돌된 객체가 있는가?
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hits, 20) == true)
            {
                lr.SetPosition(1, new Vector3(0, 0, hits.distance));
                switch (hits.transform.gameObject.name)
                {
                    case "Travel1_Btn":
                        btn = hits.transform.GetComponent<Button>();
                        FirstArtBtn();
                        break;

                    case "Travel2_Btn":
                        btn = hits.transform.GetComponent<Button>();
                        SecondArtBtn();
                        break;
                    
                }
            }

            else
            {
                if (btn != null)
                {
                    btn = null;
                }

                lr.SetPosition(1, new Vector3(0, 0, 20f));
            }
        }
    }

    public void FirstArtBtn()
    {
        GameManager_minji.objs.SetActive(false);
        SceneManager.LoadScene("Travel_1");
    }

    public void SecondArtBtn()
    {
        GameManager_minji.objs.SetActive(false);
        SceneManager.LoadScene("Travel_2");
    }
    
}
