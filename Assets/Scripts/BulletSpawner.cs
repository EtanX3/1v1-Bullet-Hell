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

    private GameObject ProjectilePrefab;
    private float timer = 0f;
    public bool firing;

    public void Fire(Vector3 shootDir, GameObject _parent)
    {
        if(bullet)
        {
            ProjectilePrefab = Instantiate(bullet, transform.position, Quaternion.identity);
            ProjectilePrefab.GetComponent<Bullet>().parent = _parent;
            ProjectilePrefab.GetComponent<Bullet>().speed = speed;
            ProjectilePrefab.GetComponent<Bullet>().lifetime = bulletlifetime;
            ProjectilePrefab.GetComponent<Bullet>().Setup(shootDir);
            ProjectilePrefab.transform.rotation = transform.rotation;

            timer += Time.deltaTime;
            if (_spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
            if (timer >= fireRate)
            {
                Fire(shootDir, _parent);
                timer = 0;
            }
        }
    }
}
