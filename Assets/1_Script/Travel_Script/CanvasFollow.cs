using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollow : MonoBehaviour
{
    public Transform centerCam;

    public float distanceFromCamera;

    private void Update()
    {
        LookAvatarCam();
    }

    void LookAvatarCam()
    {
        Vector3 resultingPosition = centerCam.position + centerCam.forward * distanceFromCamera;

        transform.position = new Vector3(resultingPosition.x, resultingPosition.y, resultingPosition.z);

        transform.forward = centerCam.forward;
    }
}
