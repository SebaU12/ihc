using UnityEngine.SceneManagement;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    public GameObject player;
    public AudioClip winSound; // Agrega este campo para el sonido

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Interaccion");
        if (col.gameObject == player)
        {
            // Reproduce el sonido al ganar
            AudioSource.PlayClipAtPoint(winSound, transform.position);

            // Carga la escena "premio"
            SceneManager.LoadScene("premio");

            Debug.Log("Yes");
        }
    }
}