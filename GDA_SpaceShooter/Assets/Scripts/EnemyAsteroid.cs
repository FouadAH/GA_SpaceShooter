using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyAsteroid : MonoBehaviour
{
    public float minSpeed = 5f; // set speed of enemy asteroid
    public float maxSpeed = 8f; // set speed of enemy asteroid
    float speed;

    public Vector3 direction; // set direction of enemy asteroid
    // Start is called before the first frame update
    void Start()
    {
        //sets the direction. If you change the first value, you'll move the bullet on the x axis (left and right)
        // If you change the second value, you'll move the bullet on the y axis (up and down)
        // If you change the third value, you'll move the bullet on the z axis (front and back, don't use this it's a 2d game)
        direction = new Vector3(0, 1, 0);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * -speed * Time.deltaTime);
        // translate allows you to translate the position of the player forward
        // multiply the direction and speed to move forward, and then multiply by time in order to keep the speed consistent on all devices
    }

    public virtual void DestroyAsteroid(Collider2D collision)
    {
        GameManager.instance.AddScore();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            //first we change the score and add it through the Game Manager. More on that in that script
            //next we check the different collision types. If the collision is a bullet, destroy the bullet and the object.
            DestroyAsteroid(collision);
        }
        if (collision.CompareTag("Player"))
        {
            //here we check if the collision that happened was with the player. If it was, we call the Lose Game function through the game manager
            //we also destroy the player and then the object.
            collision.GetComponent<PlayerController>().DamagePlayer();
        }
    }
}
