using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float verticalSpeed;
    public GameObject ground;
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
