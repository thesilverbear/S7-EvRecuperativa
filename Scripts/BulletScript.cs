using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction = Vector3.right;
    private GameObject owner;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = Direction * Speed;
    }

    //seteando direccion de la bala
    public void Initialize(Vector3 direction, GameObject shooter)
    {
        Direction = direction;
        owner = shooter;
    }


    //destruir animacion de bala
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    //destruir la bala:
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == owner) return; // ignora si choca con su creador

        GruntScript grunt = other.GetComponent<GruntScript>();
        JohnMovement player = other.GetComponent<JohnMovement>();

        if (grunt != null)
        {
            grunt.Hit();
        }
        if (player != null)
        {
            player.Hit();
        }

        DestroyBullet();
    }


    public void SetOwner(GameObject shooter)
    {
        owner = shooter;
    }

}
