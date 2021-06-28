using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f; // this is the bullet's speed
    private Vector3 direction; // sets the direction that the speed will go. If you change the different x/y/z values the bullet will move in different directions
    // Start is called before the first frame update
    void Start()
    {
        //sets the direction. If you change the first value, you'll move the bullet on the x axis (left and right)
        // If you change the second value, you'll move the bullet on the y axis (up and down)
        // If you change the third value, you'll move the bullet on the z axis (front and back, don't use this it's a 2d game)
        direction = new Vector3(0, 1, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime); 
        // translate allows you to translate the position of the player forward
        // multiply the direction and speed to move forward, and then multiply by time in order to keep the speed consistent on all devices
    }
    
}
