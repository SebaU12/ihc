using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelConfirmacion;
    public CubeButton cube1;
    public CubeButton cube2;
    public CubeButton cube3;
    public CubeButton cube4;
    void Start()
    {
        Debug.Log("Inicia?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OptionSelectedTrue()
    {
        // Cambia el material del cubo al hacer clic.
        Debug.Log("Opción elegida");
        cube1.resetMaterial(); 
        cube2.resetMaterial(); 
        cube3.resetMaterial(); 
        cube4.resetMaterial(); 
        panelConfirmacion.SetActive(false);
        manageDoor door_manager = GameObject.Find("controllerDoor").GetComponent<manageDoor>();
        door_manager.RunAnimation();
    }
}
