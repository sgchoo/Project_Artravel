using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_minji : MonoBehaviour
{
    public static GameObject objs;

    void Awake()
    {
        objs = GameObject.Find("Avatar");
        objs.SetActive(true);
    }

    private void Start()
    {
        
    }
}

