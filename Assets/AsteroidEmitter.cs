using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitter : MonoBehaviour
{

    public GameObject asteroid;
    public float minDelay, maxDelay;//delay between start

    float nextLaunchTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.isStarted)
        {
            return;
        }

        if (Time.time > nextLaunchTime)
        {
            Vector3 asteroidPosition = new Vector3(Random.Range(-transform.localScale.x/2, transform.localScale.x/2), 0,
                transform.position.z);
            Instantiate(asteroid, asteroidPosition, Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);

        }
        
    }
}
