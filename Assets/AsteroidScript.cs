using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    Rigidbody asteroid;

    public float rotationSpeed;
    public float speed;
    float mult;


    // Start is called before the first frame update
    void Start()
    {
        mult = Random.Range(0.5f, 2);

        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        asteroid.velocity = new Vector3(0, 0, -speed*mult);
        asteroid.transform.localScale /= mult;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //при столкновении с другим коллайдером
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "Grinder")
        {
            return;
        }

        GameObject newExplode = Instantiate(asteroidExplosion, asteroid.transform.position, Quaternion.identity);
        newExplode.transform.localScale /= mult;

        if (other.tag == "Player")
        { 
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);

        }

        GameController.score += 10;

        Destroy(gameObject); //уничтожает текущий игровой объект
        Destroy(other.gameObject); //уничтожаепм то с чем столкнулись
        

    }
}
