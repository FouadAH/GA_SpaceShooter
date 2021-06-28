using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    //this destroyer is basicaly a garbage collector. we use it to make sure we dont have too many items in the game that could cause a crash.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //destroy a game object if it's a trigger
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject); //destroy a game object if it's a collider
    }
}
