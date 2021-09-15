using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float projectileSpeed = 1000;
    public float nextShot = 0.0f;
    public float fireRate = 0.5f;
    public GameObject projectile;

    Vector3 lastDirection;
    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMovement, yMovement, 0);

        movement.Normalize();

        if(movement.magnitude > 0)
        {
            transform.Translate(movement * Time.deltaTime * speed);
            lastDirection = movement;
        }
        
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShot)
        {
            Shoot();
            nextShot = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
        p.GetComponent<Rigidbody2D>().AddForce(lastDirection * projectileSpeed);
        Destroy(p, 5);
    }
}
