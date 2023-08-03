using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColorPixels : MonoBehaviour
{
    [SerializeField] Image image; //컬러칩
    public AudioClip clip;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckColor();
    }

    void CheckColor()
    {
        Vector3 pos = transform.position;
        RaycastHit hit;

        //오브젝트의 Collider는 MeshCollider로 지정한 후 실행 필요.
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (Physics.Raycast(pos, this.transform.forward, out hit)) //무한대로 쏴줌.
            {
                //레이에 닿은 객체의 텍스처를 불러온다
                ColorData.tex = hit.transform.gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
                //닿은 위치의 RaycastHit에서 텍스트 좌표 값을 저장해서
                Vector2 uv = hit.textureCoord;
                //저장된 uv 벡터 변수와 오브젝트의 텍스트 크기를 이용해서 현재 찍힌 위치 값을 계산해서 픽셀 데이터를 저장
                ColorData.Pixel = ColorData.tex.GetPixels(Mathf.FloorToInt(uv.x * ColorData.tex.width), Mathf.FloorToInt(uv.y * ColorData.tex.height), 1, 1);
                //아래는 데이터 저장값 확인 코드
                //text.text = Pixel[0].ToString(); //색상코드 비활성화
                image.color = ColorData.Pixel[0];
                StartCoroutine(VibrationController(1f, 1f, 0.4f, OVRInput.Controller.RTouch));
            }
        }
    }

    //컨트롤러 진동 시작 및 종료 코루틴
    IEnumerator VibrationController(float frequency, float amplitude, float waitTime, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
