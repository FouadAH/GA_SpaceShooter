using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAsteroid : EnemyAsteroid
{
    public override void DestroyAsteroid(Collider2D collision)
    {
        Explode();
        GameManager.instance.AddScore();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Debug.Log("EXPLODE");
        for (int i = 0; i < Random.Range(4, 8); i++)
        {
            GameObject asteroid = Instantiate(AsteroidManager.instance.Asteroid_S[0], transform.position, transform.rotation);
            asteroid.transform.Rotate(new Vector3(0, 0, Random.Range(-70, 70)));
            asteroid.GetComponent<EnemyAsteroid>().minSpeed = 3;
            asteroid.GetComponent<EnemyAsteroid>().maxSpeed = 6;

        }
        //Instantiate(AsteroidManager.instance.Asteroid_S, transform.position, transform.rotation);
        //Instantiate(AsteroidManager.instance.Asteroid_S, transform.position, transform.rotation);
        //Instantiate(AsteroidManager.instance.Asteroid_S, transform.position, transform.rotation);
        //Instantiate(AsteroidManager.instance.Asteroid_S, transform.position, transform.rotation);

    }
}
