using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walksoundJMW : MonoBehaviour
{
    AudioSource walk_wav;
    
    //Unity���� ����ϴ� ��ü �ڷ���
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

            // �̵���ƾ
            //this.transform.Translate(Vector3.forward * Time.deltaTime * 5f * dir.y);
            
            // �Ѿ��� ����� -> ���? �Ѿ��� ������?
            //Transform temp = Instantiate(this.bullet);
            //temp.transform.position = firePos.transform.position;
            //print("�߻�");
            
            if(walk_wav.isPlaying == true) //������̸�
            {
                walk_wav.Stop();   //���߰�
            }
            walk_wav.Play();
        }

    }


    
}