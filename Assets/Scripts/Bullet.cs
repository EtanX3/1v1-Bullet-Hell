using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public float rotation;
    public float speed = 5f;

    private Vector3 shootDir;
    private Vector2 spawnPoint;
    private float timer = 0f;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }
    public void Setup(Vector3 _shootDir)
    {
        this.shootDir = _shootDir;
    }
    private void Update()
    {
        
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += shootDir * speed * Time.deltaTime;
       
    }
}
