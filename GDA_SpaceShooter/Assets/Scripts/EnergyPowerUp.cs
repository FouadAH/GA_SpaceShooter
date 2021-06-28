using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPowerUp : MonoBehaviour
{
    public float speed = 1f; // set speed of enemy asteroid
    public Vector3 direction; // set direction of enemy asteroid

    void Start()
    {
        direction = new Vector3(0, 1, 0);
    }

    void Update()
    {
        transform.Translate(direction * -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //here we check if the collision that happened was with the player. If it was, we call the Lose Game function through the game manager
            //we also destroy the player and then the object.
            collision.GetComponent<PlayerController>().HealPlayer();
            Destroy(gameObject);
        }
    }
}
