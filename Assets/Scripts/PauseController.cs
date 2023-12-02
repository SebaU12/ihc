using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject panelPause;
    public Transform playerCamera;

    private OVRInput.Controller leftController = OVRInput.Controller.LTouch;

    private void Start()
    {
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start, leftController))
        {
            panelPause.transform.position = playerCamera.position + playerCamera.forward * 2f;
            panelPause.transform.rotation = playerCamera.rotation;
            panelPause.SetActive(!panelPause.activeSelf);
        }
    }
}
