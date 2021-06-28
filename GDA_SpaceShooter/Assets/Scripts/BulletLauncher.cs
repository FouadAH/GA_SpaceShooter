using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    public GameObject bullet; // sets the bullet gameobject. This is what we're going to pew pew from the spaceship
    public float timeBetweenBullets = 0.1f; // sets the time between the bullets
    private float timeUntilNextBullet; // sets the time between each bullet

    public float gunHeat = 0;
    public float maxGunHeat = 200;

    void Start()
    {
        gunHeat = Mathf.Clamp(gunHeat, 0, 200);
        timeUntilNextBullet = timeBetweenBullets; //sets the time between bullets
    }
    
    void Update()
    {
        ShootABullet(); //shoots a bullet. Plain and simple name.
    }

    private void ShootABullet()
    {
        //gets the input either as Fire1 or Jump, if you click and hold, as long as the time until next bullet is under 0 we shoot and reset the timer
        //if it's more then we subtract
        //if the player removes their hand from the button then reset the timer

        gunHeat = Mathf.Clamp(gunHeat, 0, 200);

        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && gunHeat < maxGunHeat)
        {
            gunHeat += 2f;

            if (timeUntilNextBullet < 0 && gunHeat < maxGunHeat)
                Shoot();

            timeUntilNextBullet -= Time.deltaTime;
            
        }
        else if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Jump"))
        {
            timeUntilNextBullet = -1;
            gunHeat -= 1f;
        }
        else
        {
            gunHeat -= 1f;
        }
    }
    private void Shoot()
    {
        //Shoot creates a new bullet and sets it at the position and rotation of whatever the player controller is attached to, then resets the time between bullets
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        timeUntilNextBullet = timeBetweenBullets;
    }
}
