using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private string nameScene;
    public string NameScene
    {
        get { return nameScene; }
        set { nameScene = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        Debug.Log(nameScene);
        SceneManager.LoadScene(nameScene);
    }
}
