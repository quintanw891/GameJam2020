using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y + (speed * Time.deltaTime),
                                         transform.position.z);
    }
}
