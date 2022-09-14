using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer playerSprite;

    public float speed;
    private Transform playerTransform;
    private bool canShoot;
    public float timeBetweenShots;
    private float shotTimer;

    [SerializeField]
    private GameObject[] bullet_spawnPositions;

    public GameObject bulletPrefab;

    private bool powerUpOn;
    private float powerUpTimer;
    private float powerUpMaxTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerTransform = this.gameObject.transform;
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimeBetweenShots();
        Move();
        Shoot();

        if (powerUpOn) 
        { 
            powerUpTimer += Time.deltaTime;
            if (powerUpTimer >= powerUpMaxTime) {
                powerUpTimer = 0;
                powerUpOn = false;

            }
        }
    }

    private void Move() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            playerTransform.position += (Vector3.left * speed * Time.deltaTime) / 5;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerTransform.position += (Vector3.right * speed * Time.deltaTime) / 5;
        }
    }

    private void Shoot() {
        /*if (Input.GetKey(KeyCode.Space)) {
            Instantiate(bulletPrefab, playerTransform);
        }*/

        if (canShoot) {
            canShoot = false;
            for (int i = 0; i < bullet_spawnPositions.Length; i++)
            {
                GameObject bullet_1 = Instantiate(bulletPrefab, bullet_spawnPositions[i].transform);
                bullet_1.transform.parent = null;
            }
            
        }
    }

    private void TimeBetweenShots() {
        shotTimer += Time.deltaTime;
        if (shotTimer >= timeBetweenShots) {
            canShoot = true;
            shotTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("GAME OVER");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp")) {
            int randomInt = Random.Range(0, 2);
            if (randomInt == 0) 
            {
                powerUpOn = true;
                speed *= 2;
            }
            else if (randomInt == 1)
            {
                powerUpOn = true;
                timeBetweenShots *= 0.5f;
            }
            Destroy(collision.gameObject);
        }
    }

}
