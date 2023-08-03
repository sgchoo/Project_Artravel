using System.IO;
using UnityEngine;
public class ScreenShot_Manager_Travel_1 : MonoBehaviour
{
    //찍은 사진 정보
    static byte[] bytes;

    // 캔버스를 찍을 서브 카메라
    public Camera Sub_Camera1;

    //사진 저장 경로
    static string path;


    void Start()
    {
        //사진 저장 경로
        path = Application.dataPath + "/ScreenShot/";
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Canvas_ScreenShot1();
        }
    }

    // 서브 카메라를 통한 스크린샷 후 PNG 확장자로 파일 저장
    public void Canvas_ScreenShot1()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        RenderTexture rt = new RenderTexture(1920, 1080, 32);
        Sub_Camera1.targetTexture = rt;
        Texture2D screenShot1 = new Texture2D(1920, 1080, TextureFormat.RGBA32, false);
        Rect rect = new Rect(0, 0, screenShot1.width, screenShot1.height);
        Sub_Camera1.Render();
        RenderTexture.active = rt;
        screenShot1.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
        screenShot1.Apply();

        bytes = screenShot1.EncodeToPNG();
        string filePath1 = Application.dataPath + "/ScreenShot/Capture1.png";
        File.WriteAllBytes(filePath1, bytes);

        PlayerPrefs.SetString("Capture1.png", filePath1);
        Picture_Manager.shot_Count1++;

    }

}