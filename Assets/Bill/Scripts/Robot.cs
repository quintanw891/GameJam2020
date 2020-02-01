﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Robot : MonoBehaviour
{
    private bool repaired;
    public Projectile projectile;
    public float fireRate;
    private float nextFire;
    public EnemySpawner enemySpawner;
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        repaired = true;
        rb = GetComponent<Rigidbody2D>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Move toward next target enemy
        float direction;
        if (enemySpawner.spawnedEnemies.Count > 0)
        {
            Enemy enemy = enemySpawner.spawnedEnemies[enemySpawner.spawnedEnemies.Count - 1];
            direction = 1f;
            if (transform.position.x > enemy.transform.position.x)
            {
                direction = -1f;
            }
            rb.velocity = new Vector2(Mathf.Abs(transform.position.x - enemy.transform.position.x) * direction, 0f);
            //Debug.Log("Robo: " + transform.position.x + "  Enemy: " + enemy.transform.position.x);

            //Fire projectiles at a fixed rate
            if (Time.time > nextFire)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
