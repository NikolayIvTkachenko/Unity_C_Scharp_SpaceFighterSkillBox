using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float xMin, xMax, ZMin, ZMax;
    public float tilt;
    Rigidbody ship;

    //Laser
    public GameObject lazer;
    public GameObject lazerGun;

    public float shotDelay; //delay 0.3
    float nextShotTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        //ship.velocity = new Vector3(20, 0 ,20);
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float positionX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float positionZ = Mathf.Clamp(ship.position.z, ZMin, ZMax);

        ship.position = new Vector3(positionX, 0, positionZ);

        ship.rotation = Quaternion.Euler(tilt * ship.velocity.z, 0, tilt * -ship.velocity.x);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(lazer, lazerGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }



    }
}
