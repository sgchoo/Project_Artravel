using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorData : MonoBehaviour
{
    bool checkCanvas;

    public GameObject canvasObj;
    //[SerializeField] Text text; //�����ڵ�
    [SerializeField] Image imageColor; //�÷�Ĩ
    [SerializeField] GameObject currentImg; //�÷�Ĩ
    AudioSource source;
    public AudioClip clip;

    //Texture2D tex;//
    //Color[] Pixel;

    //private List<GameObject> selectobj = new List<GameObject>();

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        SetColor();
        ShowCanvas();
    }

    void SetColor()
    {
        //���콺 ��Ŭ���� ������
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            //���콺 ��ġ���� ray�� ���� �浹�� ������Ʈ�� ������.
            RaycastHit hit_2;

            if (Physics.Raycast(transform.position, transform.forward, out hit_2))
            {
                if (hit_2.transform.tag == "Canvas")
                {
                    MeshRenderer render = hit_2.transform.GetComponent<MeshRenderer>();
                    render.material.color = ColorData.Pixel[0];
                }
                StartCoroutine(VibrationController(1f, 1f, 0.4f, OVRInput.Controller.LTouch));
            }
        }
    }

    void ShowCanvas()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            if (checkCanvas == false)
            {
                canvasObj.SetActive(true);
                currentImg.SetActive(true);
                checkCanvas = true;
            }

            else
            {
                canvasObj.SetActive(false);
                currentImg.SetActive(false);
                checkCanvas = false;
            }
        }
    }

    //��Ʈ�ѷ� ���� ���� �� ���� �ڷ�ƾ
    IEnumerator VibrationController(float frequency, float amplitude, float waitTime, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}

