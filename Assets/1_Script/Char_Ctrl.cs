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
        // vr������ thumbstick �� ������ ��´�
        // x,y �������� vector2     Axis2D

        //pc��� new vector2(Input.GetAxis(""),Input.GetAxis(""));
        Vector2 dir = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        // �̵���ƾ
        this.transform.Translate(Vector3.forward * Time.deltaTime * 5f * dir.y);
        this.transform.Rotate(Vector3.up * Time.deltaTime * 90f * dir.x);

    }
}
