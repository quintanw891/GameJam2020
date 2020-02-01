using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (Time.deltaTime * 0.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OUTER");
        if (collision.collider.CompareTag("Projectile") ||
            collision.collider.CompareTag("Ground"))
        {
            Debug.Log("CONTACT");
            Destroy(collision.collider);
            Destroy(this);
        }
    }
}
