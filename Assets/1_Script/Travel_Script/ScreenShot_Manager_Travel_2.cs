using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenShot_Manager_Travel_2 : MonoBehaviour
{

    //���� ���� ����
    static byte[] bytes;

    // ĵ������ ���� ���� ī�޶�
    public Camera Sub_Camera2;

    //���� ���� ���
    static string path;

    void Start()
    {
        //���� ���� ���
        path = Application.dataPath + "/ScreenShot/";
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Canvas_ScreenShot2();
        }
    }
    // ���� ī�޶� ���� ��ũ���� �� PNG Ȯ���ڷ� ���� ����

    public void Canvas_ScreenShot2()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        RenderTexture rt = new RenderTexture(1920, 1080, 32);
        Sub_Camera2.targetTexture = rt;
        Texture2D screenShot2 = new Texture2D(1920, 1080, TextureFormat.RGBA32, false);
        Rect rect = new Rect(0, 0, screenShot2.width, screenShot2.height);
        Sub_Camera2.Render();
        RenderTexture.active = rt;
        screenShot2.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
        screenShot2.Apply();

        bytes = screenShot2.EncodeToPNG();
        string filePath2 = Application.dataPath + "/ScreenShot/Capture2.png";
        File.WriteAllBytes(filePath2, bytes);

        PlayerPrefs.SetString("Capture2.png", filePath2);
        Picture_Manager.shot_Count2++;
    }

    public void movemove()
    {
        SceneManager.LoadScene("Gallery1");
    }
}