using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Picture_Manager : MonoBehaviour
{
    //여행지마다 찍은 사진 구분 카운트
    public static int shot_Count1;
    public static int shot_Count2;

    //찍은 사진이 담길 이미지 UI 분리
    public GameObject empty_Art1;
    public GameObject empty_Art2;


    void Start()
    {

        string filePath1 = PlayerPrefs.GetString("Capture1.png", "");
        if (Picture_Manager.shot_Count1 >= 1)
        {
            byte[] bytes1 = File.ReadAllBytes(filePath1);
            Texture2D texture1 = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            texture1.LoadImage(bytes1);
            empty_Art1.GetComponent<RawImage>().texture = texture1;

        }
        string filePath2 = PlayerPrefs.GetString("Capture2.png", "");
        if (Picture_Manager.shot_Count2 >= 1)
        {
            byte[] bytes2 = File.ReadAllBytes(filePath2);
            Texture2D texture2 = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            texture2.LoadImage(bytes2);
            empty_Art2.GetComponent<RawImage>().texture = texture2;

        }
    }
}