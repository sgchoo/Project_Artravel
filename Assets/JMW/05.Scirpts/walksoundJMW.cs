using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walksoundJMW : MonoBehaviour
{
    AudioSource walk_wav;
    
    //Unity에서 사용하는 객체 자료형
    //GameObject

   
    void Start()
    {
        walk_wav = this.GetComponent<AudioSource>();
        walk_wav.loop = false;
        walk_wav.playOnAwake = false;
        //bullet2.transform.gameObject

        Vector2 thumbstickValue = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
    }


    void Update()
    {


        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) != Vector2.zero)
        {

            // 이동루틴
            //this.transform.Translate(Vector3.forward * Time.deltaTime * 5f * dir.y);
            
            // 총알을 만든다 -> 어떻게? 총알의 정보는?
            //Transform temp = Instantiate(this.bullet);
            //temp.transform.position = firePos.transform.position;
            //print("발사");
            
            if(walk_wav.isPlaying == true) //재생중이면
            {
                walk_wav.Stop();   //멈추고
            }
            walk_wav.Play();
        }

    }


    
}