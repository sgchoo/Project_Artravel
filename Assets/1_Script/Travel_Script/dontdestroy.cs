using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dontdestroy : MonoBehaviour
{
    public static GameObject objs;
    private void Awake()
    {
        var objs = FindObjectsOfType<dontdestroy>();
        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
