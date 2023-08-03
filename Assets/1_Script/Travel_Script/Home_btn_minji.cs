using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home_btn_minji : MonoBehaviour
{
    Button btn;
    LineRenderer lr;
    RaycastHit hits;

    // Start is called before the first frame update
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
            // ray를 발사해서 충돌된 객체가 있는가?
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hits) == true)
            {
                lr.SetPosition(1, new Vector3(0, 0, hits.distance));
                switch (hits.transform.gameObject.name)
                {
                    case "Home_btn":
                        btn = hits.transform.GetComponent<Button>();
                        HOME_Btn();
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
    public void HOME_Btn()
    {
        SceneManager.LoadScene("Gallery");
    }


}
