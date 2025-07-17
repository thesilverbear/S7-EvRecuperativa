using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JohnMovement : MonoBehaviour
{
    //componentes públicos
    public UnityEngine.UI.Text LivesText;
    public GameObject GameOverScreen;
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;
    public int maxLives = 2;

    // componentes privados
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot; //para controlar cuantas balas salen
    private int Health = 5;
    private Vector3 respawnPoint;
    private int currentLives;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        respawnPoint = transform.position;
        currentLives = maxLives;
        UpdateLivesUI();
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Para cambiar la dirección del sprite:
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }



        //Raycast para ver si hay suelo justo debajo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f)) // Aumentado un poco el rayo por si acaso
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // if para saltar con W:
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        // if para disparar con espacio:
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f) 
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * Speed, Rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, 0);
        Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(direction, gameObject);
    }

    public void Hit()
    {
        Health--;

        if (Health <= 0)
        {
            currentLives--;

            if (currentLives >= 0)
            {
                transform.position = respawnPoint;
                Rigidbody2D.linearVelocity = Vector2.zero;
                Health = 5;
            }
            else
            {
                if (GameOverScreen != null)
                {
                    GameOverScreen.SetActive(true);
                    if (GameOverScreen.GetComponent<GameOverManager>() != null)
                    {
                        GameOverScreen.GetComponent<GameOverManager>().ActivateGameOver();
                    }
                }
                Time.timeScale = 0f;
            }

            UpdateLivesUI();
        }
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
    }

    private void UpdateLivesUI()
    {
        if (LivesText != null)
        {
            LivesText.text = "Vidas: " + (currentLives + 1);
        }
    }
}