using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AttackTemplate
{
    //public getters to allow public access, but not modification
    public GameObject Prefab => _projectilePrefab;
    public int Number => _numberOfProj;
    public float Speed => _projSpeed;
    public float Radius => _spawnRadius;
    public float Angle => _angle;
    public float AngleStep => _angleStep;


    //private variables to hold template data
    private GameObject _projectilePrefab;
    private int _numberOfProj;
    private float _projSpeed;
    private float _spawnRadius;
    private float _angle;
    private float _angleStep;

    //constructor to set up the template
    public AttackTemplate(GameObject projectilePrefab, int numberOfProj = 1,
        float projSpeed = 15f, float spawnRadius = 1f, float angle = 0f, float angleStep = 180f)
    {
        _projectilePrefab = projectilePrefab;
        _numberOfProj = numberOfProj;
        _projSpeed = projSpeed;
        _spawnRadius = spawnRadius;
        _angle = angle;
        _angleStep = angleStep;
    }
}
