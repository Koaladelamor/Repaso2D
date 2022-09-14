using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float hp;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet")) {
            Destroy(collision.gameObject);
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
