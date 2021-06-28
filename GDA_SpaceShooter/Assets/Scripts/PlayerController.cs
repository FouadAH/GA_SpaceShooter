using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f; // player speed
    private Camera mainCamera; // main camera

    private Vector2 screenBounds; // screen bounds, specifically used to make sure your player stays in the screen bounds
    private float objectWidth; // sets the object width
    private float objectHeight; // sets the object height

    int health;
    public int maxHealth = 3;
    DamageEffect damageEffect;

    bool isDamagable = true;
    int IFrames = 2;

    public BulletLauncher BulletLauncher;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // sets the camera as the main camera
        health = maxHealth;

        //the 3 lines below allow us to fly our plane in the screen we have and no where else.  They simply set the bounds of the screen and our object for use in the lateupdate
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

        damageEffect = GameManager.instance.damageEffect;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlane(); //moves the plane, what exactly did you expect?       
    }

    void LateUpdate()
    {
        //everything here helps set your ship to stay in the middle of the scene and not stray away from the camera's view
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

    private void MovePlane()
    {
        //To move the plane, we need to check if the player clicked the horizontal or vertical input buttons (arrow keys or wasd)
        //we multiply the input by the speed to move at a specific speed, and by time so that it moves at the same time on all machines
        float horizontalSpeed = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float verticalSpeed = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        gameObject.transform.Translate(horizontalSpeed,verticalSpeed,0);
    }

    public void HealPlayer()
    {
        if (health < maxHealth)
        {
            GameManager.instance.AddHealth(1);
            health += 1;
        }
    }

    public void DamagePlayer()
    {
        if (isDamagable)
        {
            StartCoroutine(DamageBuffer());
            damageEffect.flash = true;
            GameManager.instance.RemoveHealth(1);
            health -= 1;
            CheckPlayerHealth();
        }
    }

    int frameCount = 0;

    IEnumerator DamageBuffer()
    {
        while (frameCount > IFrames)
        {
            isDamagable = false;
            frameCount++;
            yield return null;
        }

        frameCount = 0;
        isDamagable = true;
    }

    void CheckPlayerHealth()
    {
        if(health <= 0)
        {
            GameManager.instance.LoseGame();
            Destroy(gameObject);
        }
    }

}
