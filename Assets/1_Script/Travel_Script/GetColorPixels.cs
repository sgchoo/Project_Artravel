using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColorPixels : MonoBehaviour
{
    [SerializeField] Image image; //�÷�Ĩ
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

        //������Ʈ�� Collider�� MeshCollider�� ������ �� ���� �ʿ�.
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (Physics.Raycast(pos, this.transform.forward, out hit)) //���Ѵ�� ����.
            {
                //���̿� ���� ��ü�� �ؽ�ó�� �ҷ��´�
                ColorData.tex = hit.transform.gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
                //���� ��ġ�� RaycastHit���� �ؽ�Ʈ ��ǥ ���� �����ؼ�
                Vector2 uv = hit.textureCoord;
                //����� uv ���� ������ ������Ʈ�� �ؽ�Ʈ ũ�⸦ �̿��ؼ� ���� ���� ��ġ ���� ����ؼ� �ȼ� �����͸� ����
                ColorData.Pixel = ColorData.tex.GetPixels(Mathf.FloorToInt(uv.x * ColorData.tex.width), Mathf.FloorToInt(uv.y * ColorData.tex.height), 1, 1);
                //�Ʒ��� ������ ���尪 Ȯ�� �ڵ�
                //text.text = Pixel[0].ToString(); //�����ڵ� ��Ȱ��ȭ
                image.color = ColorData.Pixel[0];
                StartCoroutine(VibrationController(1f, 1f, 0.4f, OVRInput.Controller.RTouch));
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
