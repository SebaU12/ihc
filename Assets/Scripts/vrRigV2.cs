using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrRigV2 : MonoBehaviour
{
    public Transform rightTouch;
    public float raycastMaxDistance = 10.0f;
    public GameObject whiteLine;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = whiteLine.GetComponent<LineRenderer>();
        
        lineRenderer.positionCount = 2;
        lineRenderer.widthCurve = AnimationCurve.Constant(0, 1, 0.1f);

        whiteLine.SetActive(false);
    }

    void Update()
    {
        bool triggerButtonPressed = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
        Ray ray = new Ray(rightTouch.position, rightTouch.forward);
        RaycastHit hit;

        if (triggerButtonPressed)
        {
            whiteLine.SetActive(true);
            Vector3 lineStartPosition = rightTouch.position + rightTouch.forward * 0.1f;

            if  (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Raycast hit: " + hit.transform.name);
                lineRenderer.SetPosition(0, lineStartPosition);
                lineRenderer.SetPosition(1, hit.point);
                CubeButton cubeButton = hit.collider.GetComponent<CubeButton>();
                controllerButton cbyes = hit.collider.GetComponent<controllerButton>();
                controllerButtonNo cbno = hit.collider.GetComponent<controllerButtonNo>();
                goLevelSelector home_button = hit.collider.GetComponent<goLevelSelector>();
                pauseYes pause_button_yes = hit.collider.GetComponent<pauseYes>();
                pauseNo pause_button_no = hit.collider.GetComponent<pauseNo>();
                if (cubeButton != null)
                {
                    cubeButton.OnCubeTouched(); 
                }
                if (cbyes != null) 
                {
                    cbyes.OptionSelectedTrue();
                }
                if (cbno != null) 
                {
                    cbno.OptionSelectedFalse();
                }
                if (home_button != null)
                {
                    home_button.GoHome();
                }
                if (pause_button_yes != null)
                {
                    pause_button_yes.pauseButton();
                }
                if (pause_button_no != null){
                    pause_button_no.pauseButton();
                }
            }
            else
            {
                lineRenderer.SetPosition(0, lineStartPosition);
                lineRenderer.SetPosition(1, ray.origin + ray.direction * raycastMaxDistance);
            }
        }
        else
        {
            whiteLine.SetActive(false);
        }
    }
}
