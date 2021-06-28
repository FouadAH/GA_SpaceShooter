using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Asteroid_S;
    public GameObject[] Asteroid_M;
    public GameObject[] Asteroid_L;
    public GameObject[] Ship;

    //public float Asteroid_S_SpawnRate = 80f;
    public float Asteroid_M_SpawnRate = 60f;
    public float Asteroid_L_SpawnRate = 10f;


    public static AsteroidManager instance; //this is called an instance. It's not a beginner's topic but to simplify it greatly, this is something that only exists once in all the game
    private void Awake()
    { 
        //and the code in this Awake function makes sure we only have one instance of the Game Manager all over
        //we need this because it's the one thing all aspects of the game will be talking to (eg we can have many bullets, but only one game manager)
        if(instance == null)
        {
            //set instance to this object
            instance = this;
        }
        else
        {
            //destroy the this object if another one like it exists
            Destroy(gameObject);
        }
    }

}
