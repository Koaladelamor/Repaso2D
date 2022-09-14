using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    //public GameObject player;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //if (player == null) { player = GameObject.FindGameObjectWithTag("Player"); }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
    }


    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
