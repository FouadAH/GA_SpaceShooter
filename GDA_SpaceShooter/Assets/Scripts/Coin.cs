using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
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
            GameManager.instance.AddScore();
            Destroy(gameObject);
        }
    }
}
