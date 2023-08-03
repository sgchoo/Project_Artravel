using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Ctrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharMove();
    }

    void CharMove()
    {
        // vr에서는 thumbstick 의 정보를 얻는다
        // x,y 형식으로 vector2     Axis2D

        //pc라면 new vector2(Input.GetAxis(""),Input.GetAxis(""));
        Vector2 dir = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        // 이동루틴
        this.transform.Translate(Vector3.forward * Time.deltaTime * 5f * dir.y);
        this.transform.Rotate(Vector3.up * Time.deltaTime * 90f * dir.x);

    }
}
