using UnityEngine;

public class ReproductorSonidoTrafico : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource caminarAudioSource;
    private AudioSource vientoAudioSource;

    public AudioClip sonidoTrafico; // Asigna el sonido de tr�fico en el Inspector
    public AudioClip sonidoCaminar;
    public AudioClip sonidoViento;

    public float umbralVelocidad = 0.1f; // Umbral de velocidad para detectar el movimiento
    public float duracionPaso = 1.0f; // Duraci�n del sonido de un paso en segundos

    void Start()
    {
        // Obt�n o agrega el componente AudioSource

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

        // Puedes ajustar el volumen del viento seg�n sea necesario
        vientoAudioSource.volume = 0.5f;

        audioSource = GetComponent<AudioSource>();

        // Si no hay un componente AudioSource, agr�galo
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asigna el sonido de tr�fico al AudioSource
        if (audioSource != null && sonidoTrafico != null)
        {
            audioSource.clip = sonidoTrafico;
            audioSource.Play(); // Reproduce el sonido de tr�fico al inicio
        }
    }

    void Update()
    {
        // Verificar si la velocidad del objeto es mayor que el umbral
        if (GetComponent<Rigidbody>().velocity.magnitude > umbralVelocidad)
        {
            // Si est� en movimiento y el sonido de caminar no se est� reproduciendo, iniciarlo
            if (!caminarAudioSource.isPlaying)
            {
                caminarAudioSource.Play();
                Invoke("DetenerSonidoCaminar", duracionPaso); // Llama a la funci�n DetenerSonidoCaminar despu�s de duracionPaso segundos
            }
        }
    }

    // Funci�n para detener el sonido de caminar
    void DetenerSonidoCaminar()
    {
        caminarAudioSource.Stop();
    }
}
