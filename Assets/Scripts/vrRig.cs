using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrRig : MonoBehaviour
{
    public Transform player; 
    public Transform cameraTransform; 

    public float playerSpeed = 1.0f; 
    public float cameraRotationSpeed = 1.0f; 
    public float raycastMaxDistance = 10.0f; 

    public bool triggerButtonPressed; 
    public GameObject whiteLine; 

    // Update is called once per frame
    void Update()
    {
        Vector2 leftStick = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector3 playerMovement = new Vector3(-leftStick.x, 0.0f, -leftStick.y) * playerSpeed;
        player.Translate(playerMovement * Time.deltaTime);
        Vector2 rightStick = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        cameraTransform.Rotate(Vector3.up, rightStick.x * cameraRotationSpeed);
        triggerButtonPressed = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;
        if(triggerButtonPressed){
            Debug.Log("Hola has presionado");
        }
        if (triggerButtonPressed && Physics.Raycast(ray, out hit, raycastMaxDistance))
        {
            Debug.Log("Raycast hit: " + hit.transform.name);

            whiteLine.SetActive(true);
            whiteLine.transform.position = cameraTransform.position;
            whiteLine.transform.LookAt(hit.point);
            whiteLine.transform.localScale = new Vector3(1.0f, 1.0f, Vector3.Distance(cameraTransform.position, hit.point));
            CubeButton cubeButton = hit.collider.GetComponent<CubeButton>();
            
            if (cubeButton != null)
            {
                cubeButton.OnCubeTouched(); // Llama a la función en CubeButton
            }
        }
        else
        {
            whiteLine.SetActive(false);
        }
    }
}