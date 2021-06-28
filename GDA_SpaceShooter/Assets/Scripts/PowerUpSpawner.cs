using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn; //here's an array (think of it as a list) of objects to spawn. You can add them through the Unity editor
    [SerializeField] private GameObject[] endPointsToMoveTo; //here's an array of points you want the spawner to move to/from. Add as many as you like by creating different gameobjects on screen and adding them through the editor
    private int currentEndPointCount = 0; //set the initial end point count to 0 the array counts start at 0 and go to amount-1 (eg if we have 10 items their numbers are 0-9, not 1-10)
    public float timeToSpawn = 1f; //set the time to spawn these objects. Increase it for more difficulty, decrease it for less.
    private float timeLeftToSpawn; //time left until the next object is spawned
    public float speed = 5f; //speed of the spawner. The faster it is the faster it moves from left to right

    // Start is called before the first frame update
    void Start()
    {
        //if you didn't set any endpoints, it will set the current position as the endpoint
        if (endPointsToMoveTo.Length < 1)
        {
            endPointsToMoveTo[0] = gameObject;
        }
        timeLeftToSpawn = timeToSpawn;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject(); //spawns an object.

        //if the distance between the spawner's current position and the spawner's next position is greater than 0.01, move towards it
        if (Vector2.Distance(gameObject.transform.position, endPointsToMoveTo[currentEndPointCount].transform.position) > 0.01f)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, endPointsToMoveTo[currentEndPointCount].transform.position, speed * Time.deltaTime);

        }
        else
        {
            //else move to the next spawn point

            currentEndPointCount++;
            //if the current end point is greater than number of end points we have, set it back to 0 and start over from the first end point
            if (currentEndPointCount >= endPointsToMoveTo.Length)
            {
                currentEndPointCount = 0;
            }
        }
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

            GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Instantiate(randomObject, gameObject.transform.position, gameObject.transform.rotation);

            //if (chance <= asteroidManager.Asteroid_L_SpawnRate)
            //{
            //    GameObject randomObject = asteroidManager.Asteroid_L[Random.Range(0, asteroidManager.Asteroid_L.Length)];
            //    Instantiate(randomObject, gameObject.transform.position, gameObject.transform.rotation);
            //}
            //else
            //{
            //    float chance1 = Random.Range(0, 100);
            //    if (chance1 <= asteroidManager.Asteroid_M_SpawnRate)
            //    {
            //        GameObject randomObject = asteroidManager.Asteroid_M[Random.Range(0, asteroidManager.Asteroid_M.Length)];
            //        Instantiate(randomObject, gameObject.transform.position, gameObject.transform.rotation);
            //    }
            //    else
            //    {
            //        GameObject randomObject = asteroidManager.Asteroid_S[Random.Range(0, asteroidManager.Asteroid_S.Length)];
            //        Instantiate(randomObject, gameObject.transform.position, gameObject.transform.rotation);
            //    }

            //}

        }
    }
}
