using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseNo: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelPause;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseButton()
    {
        panelPause.SetActive(false);
    }
}
