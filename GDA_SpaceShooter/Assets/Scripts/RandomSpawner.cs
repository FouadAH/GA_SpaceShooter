using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] endPointsToMoveTo; //here's an array of points you want the spawner to move to/from. Add as many as you like by creating different gameobjects on screen and adding them through the editor
    public float timeToSpawn = 1f; //set the time to spawn these objects. Increase it for more difficulty, decrease it for less.
    private float timeLeftToSpawn; //time left until the next object is spawned
    public float speed = 5f; //speed of the spawner. The faster it is the faster it moves from left to right

    AsteroidManager asteroidManager;

    // Start is called before the first frame update
    void Start()
    {
        //if you didn't set any endpoints, it will set the current position as the endpoint
        if (endPointsToMoveTo.Length < 1)
        {
            endPointsToMoveTo[0] = gameObject;
        }
        timeLeftToSpawn = timeToSpawn;

        asteroidManager = FindObjectOfType<AsteroidManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject(); //spawns an object.
    }

    private void SpawnObject()
    {
        //if the spawn time is greater than 0, decrease the time left to spawn
        if (timeLeftToSpawn > 0)
        {
            timeLeftToSpawn -= Time.deltaTime;
        }
        //else set the time left to spawn to the original time
        //choose a random object from the possible spawned objects
        //spawn it at the position and rotation of the spawner
        else
        {
            float chance = Random.Range(0, 100);
            timeLeftToSpawn = timeToSpawn;

            float randomXposition = Random.Range(endPointsToMoveTo[0].transform.position.x, endPointsToMoveTo[1].transform.position.x);
            Vector3 randomPos = new Vector3(randomXposition, transform.position.y, transform.position.z);

            if (chance <= asteroidManager.Asteroid_L_SpawnRate)
            {
                GameObject randomObject = asteroidManager.Asteroid_L[Random.Range(0, asteroidManager.Asteroid_L.Length)];
                Instantiate(randomObject, randomPos, gameObject.transform.rotation);
            }
            else
            {
                float chance1 = Random.Range(0, 100);
                if (chance1 <= asteroidManager.Asteroid_M_SpawnRate)
                {
                    GameObject randomObject = asteroidManager.Asteroid_M[Random.Range(0, asteroidManager.Asteroid_M.Length)];
                    Instantiate(randomObject, randomPos, gameObject.transform.rotation);
                }
                else
                {
                    GameObject randomObject = asteroidManager.Asteroid_S[Random.Range(0, asteroidManager.Asteroid_S.Length)];
                    Instantiate(randomObject, randomPos, gameObject.transform.rotation);
                }

            }

        }
    }
}
