using UnityEngine;

public class ReproductorSonidoTrafico : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource caminarAudioSource;
    private AudioSource vientoAudioSource;

    public AudioClip sonidoTrafico; // Asigna el sonido de tráfico en el Inspector
    public AudioClip sonidoCaminar;
    public AudioClip sonidoViento;

    public float umbralVelocidad = 0.1f; // Umbral de velocidad para detectar el movimiento
    public float duracionPaso = 1.0f; // Duración del sonido de un paso en segundos

    void Start()
    {
        // Obtén o agrega el componente AudioSource

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

        audioSource = GetComponent<AudioSource>();

        // Si no hay un componente AudioSource, agrégalo
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asigna el sonido de tráfico al AudioSource
        if (audioSource != null && sonidoTrafico != null)
        {
            audioSource.clip = sonidoTrafico;
            audioSource.Play(); // Reproduce el sonido de tráfico al inicio
        }
    }

    void Update()
    {
        // Verificar si la velocidad del objeto es mayor que el umbral
        if (GetComponent<Rigidbody>().velocity.magnitude > umbralVelocidad)
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
