using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeButton : MonoBehaviour
{
    private Material materialInicial;
    public Material materialClickeado;
    public GameObject panelConfirmacion;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
     materialInicial = GetComponent<Renderer>().material;   
    }

    private void OnMouseDown()
    {
        // Cambia el material del cubo al hacer clic.
        Debug.Log("Cubo click");
        GetComponent<Renderer>().material = materialClickeado;
        panelConfirmacion.SetActive(true);
        if (panelConfirmacion.activeInHierarchy)
        {
            TextMeshProUGUI textoTMP = panelConfirmacion.GetComponentInChildren<TextMeshProUGUI>();

            if (textoTMP != null)
            {
                // Asigna el valor al TextMeshPro
                textoTMP.text = "¿Confirmar el inicio del "+sceneName +"?";
            }
            else
            {
                Debug.LogWarning("No se encontro");
            }
        }
        GameObject manageScene = GameObject.Find("controllerScene");
        if (manageScene != null)
        {
            Debug.Log("Encontro el objeto");
            sceneManager scriptSceneManager = manageScene.GetComponent<sceneManager>();
            if (scriptSceneManager != null)
            {
                Debug.Log("Se encontro script");
                scriptSceneManager.NameScene = sceneName;
            }
        } else {
            Debug.Log("NO objeto");
        }
    }
    public void OnCubeTouched()
    {
        // Cambia el material del cubo al hacer clic.
        Debug.Log("Cubo click");
        GetComponent<Renderer>().material = materialClickeado;
        panelConfirmacion.SetActive(true);
        if (panelConfirmacion.activeInHierarchy)
        {
            TextMeshProUGUI textoTMP = panelConfirmacion.GetComponentInChildren<TextMeshProUGUI>();

            if (textoTMP != null)
            {
                // Asigna el valor al TextMeshPro
                textoTMP.text = "¿Confirmar el inicio del "+sceneName +"?";
            }
            else
            {
                Debug.LogWarning("No se encontro");
            }
        }
        GameObject manageScene = GameObject.Find("controllerScene");
        if (manageScene != null)
        {
            Debug.Log("Encontro el objeto");
            sceneManager scriptSceneManager = manageScene.GetComponent<sceneManager>();
            if (scriptSceneManager != null)
            {
                Debug.Log("Se encontro script");
                scriptSceneManager.NameScene = sceneName;
            }
        } else {
            Debug.Log("NO objeto");
        }
    }

    public void resetMaterial()
    {
        GetComponent<Renderer>().material = materialInicial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
