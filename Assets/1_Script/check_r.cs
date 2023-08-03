using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class check_r : MonoBehaviour
{
    public GameObject canv;
    public GameObject can_otp;
    public Transform r_ray;
    RaycastHit hits;
    void Start()
    {

    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)

        {
            if (Physics.Raycast(r_ray.transform.position, r_ray.forward, out hits, 20f) == true)
            {
                if (hits.transform.tag == "NextScene")
                {
                    SceneManager.LoadScene("SecondScene");
                }
                option_hit();
                option_back();

            }
        }

        //버튼 (VR 트리거) 이 눌릴때 광선을 발사하고 맞은 객체가 next scene 이면 씬이동
        // 맞은 객체가 Exit 이면 프로그램 종료
    }

    void option_hit()
    {
        if (hits.transform.tag == "Option")
        {
            can_otp.SetActive(true);

            canv.SetActive(false);

            //GameObject.Find("Canvas_opt").SetActive(true);
        }
    }

    void option_back()
    {
        if (hits.transform.tag == "Back")
        {
            can_otp.SetActive(false);

            canv.SetActive(true);

            //GameObject.Find("Canvas_opt").SetActive(true);
        }
    }
}