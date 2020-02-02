﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float verticalSpeed;
    public GameObject healthController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - (verticalSpeed * Time.deltaTime), transform.position.z);
        //Debug.Log("Value" + transform.localScale.y);
        //if (transform.position.y <= ground.transform.position.y)
        //{
        //    healthController.GetComponent<HealthController>().health--;
        //    gameObject.SetActive(false);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
        GameObject.Find("Enemy_Manager").GetComponent<Enemy_Manager>().enemyList.Remove(gameObject.transform.parent.gameObject);
        Destroy(gameObject);
    }
}
