using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Space Invaders, enemy bullet controller.
// This script is for enemy's bullets.
// Check if bullet hit on player or base and make damage them
// Destroy bullet when hit player, base or fly too far.

public class EnemyBulletController : MonoBehaviour
{

    private Transform bullet;
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if(bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject playerLife = other.gameObject;
            tankMovement tankhealth = playerLife.GetComponent<tankMovement>();
            tankhealth.health -= 1;

            Destroy(GameObject.FindGameObjectWithTag("PlayerLife"));
            Destroy(gameObject);
            
        }
        else if(other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;

            Destroy(gameObject);


        }
    }
}
