using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] asteroidSprites;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int randomNumber = Random.Range(0, 3);
        spriteRenderer.sprite = asteroidSprites[randomNumber];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

}
