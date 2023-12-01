using UnityEngine;

public class PuenteScript : MonoBehaviour
{
    private AudioSource caminarAudioSource;
    private AudioSource vientoAudioSource;

    public AudioClip sonidoCaminar;
    public AudioClip sonidoViento;

    public float duracionPaso = 1.0f; // Duración del sonido de un paso en segundos

    void Start()
    {
        // Configurar el AudioSource para el sonido de caminar
        caminarAudioSource = gameObject.AddComponent<AudioSource>();
        caminarAudioSource.clip = sonidoCaminar;
        caminarAudioSource.loop = false;

        // Configurar el AudioSource para el sonido de viento
        vientoAudioSource = gameObject.AddComponent<AudioSource>();
        vientoAudioSource.clip = sonidoViento;
        vientoAudioSource.loop = true;

        // Manejar el inicio del sonido de viento antes de permitir que el sonido de caminar se reproduzca
        vientoAudioSource.PlayDelayed(0.5f); // Retrasar el inicio del sonido de viento en 0.5 segundos

        // Puedes ajustar el volumen del viento según sea necesario
        vientoAudioSource.volume = 0.5f;
    }

    void Update()
    {
        // Verificar si el personaje está en movimiento (por ejemplo, si el eje horizontal no es cero)
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            // Si está en movimiento y el sonido de caminar no se está reproduciendo, iniciarlo
            if (!caminarAudioSource.isPlaying)
            {
                caminarAudioSource.Play();
                Invoke("DetenerSonidoCaminar", duracionPaso); // Llama a la función DetenerSonidoCaminar después de duracionPaso segundos
            }
        }
    }

    // Función para detener el sonido de caminar
    void DetenerSonidoCaminar()
    {
        caminarAudioSource.Stop();
    }
}