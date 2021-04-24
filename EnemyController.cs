using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Space Invaders, enemy controller.
// Controls enemys moving and enemy bullets.
// Check is there any enemy left and if not player win a game.

public class EnemyController : MonoBehaviour
{

    public Transform enemyHolder;
    private float speed = 0.2f;
    public GameObject shot;
    public GameObject Panel;
    public Text winText;
    private float fireRate = 0.90f;
    private float nextFire = 1;
    public static bool allEnemysDown = false;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.2f);
        enemyHolder = GetComponent<Transform>();
        Panel.gameObject.SetActive(false);
    }

    void MoveEnemy()
    {


        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder)
        {
            if(enemy.position.x < -9.5 || enemy.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.2f;
                return;
            }

            // Enemy bullet controller
            if ( Time.time > nextFire)
            {
                if (Random.value > fireRate)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, enemy.position, enemy.rotation);
                }
            }

            if (enemy.position.y <= -3)
            {
                GameOverIndice.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount <= 15 && enemyHolder.childCount >= 10)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        }

        else if (enemyHolder.childCount < 7 && enemyHolder.childCount > 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.35f);
        }

        else if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.6f);
        }


        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;
            Panel.gameObject.SetActive(true);
            allEnemysDown = true;
        }
    }

}
