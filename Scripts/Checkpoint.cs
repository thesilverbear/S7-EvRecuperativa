using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private AudioSource audioSource;
    private bool activated = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            other.GetComponent<JohnMovement>().SetCheckpoint(transform.position);
            audioSource.Play();
            activated = true; // para que no se repita el sonido del check si pasa de nuevo
        }
    }
}
