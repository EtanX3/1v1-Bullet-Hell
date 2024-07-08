using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public enum SpawnerType {  Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletlifetime = 2f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] public SpawnerType _spawnerType;
    [SerializeField] private float fireRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    public bool firing;

    public void Fire(Vector3 shootDir)
    {
        if(bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().lifetime = bulletlifetime;
            spawnedBullet.GetComponent<Bullet>().Setup(shootDir);
            spawnedBullet.transform.rotation = transform.rotation;

            timer += Time.deltaTime;
            if (_spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
            if (timer >= fireRate)
            {
                Fire(shootDir);
                timer = 0;
            }
        }
    }
}
