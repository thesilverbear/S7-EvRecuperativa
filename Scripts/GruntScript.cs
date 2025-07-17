using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public Transform Player;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;

    void Update()
    {
        if (Player == null) return;

        // Mira al jugador
        Vector3 direction = Player.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Dispara si el jugador está cerca
        float distance = Mathf.Abs(Player.position.x - transform.position.x);
        if (distance < 2.0f && Time.time > LastShoot + 1.0f) // 1 bala por segundo 
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(direction, gameObject);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}