using UnityEngine;

public class AmmoBoxTrigger : MonoBehaviour
{
    public GameObject MissionCompleted; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            // Mostrar la pantalla de misión completada
            MissionCompleted.SetActive(true);

            
            gameObject.SetActive(false);
        }
    }
}
