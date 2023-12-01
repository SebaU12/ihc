using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
    public void ComenzarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}
