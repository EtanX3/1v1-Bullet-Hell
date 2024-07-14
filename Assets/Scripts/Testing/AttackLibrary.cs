using UnityEngine;

public static class AttackLibrary
{
    private static GameObject _defaultProjPrefab;
    private static GameObject _defaultMissilePrefab; //ig?
public static void Initialize(GameObject defaultProjPrefab, GameObject defaultMissilePrefab)
    {
        _defaultProjPrefab = defaultProjPrefab;
        _defaultMissilePrefab = defaultMissilePrefab;
    }

    public static AttackTemplate OneForward() => new AttackTemplate(
        projectilePrefab: _defaultProjPrefab,
        numberOfProj: 1,
        projSpeed: 5f,
        spawnRadius: 1f,
        angle: 0f,
        angleStep: 360);
    public static AttackTemplate Eight360() => new AttackTemplate(
        projectilePrefab: _defaultProjPrefab,
        numberOfProj: 8,
        projSpeed: 6f,
        spawnRadius: 1f,
        angle: 22.5f,
        angleStep: 360);

    public static AttackTemplate SlowSpin() => new AttackTemplate(
        projectilePrefab: _defaultProjPrefab,
        numberOfProj: 6,
        projSpeed: 2,
        spawnRadius: 1f,
        angle: 0,
        angleStep: 360);
    public static AttackTemplate Shotgun() => new AttackTemplate(
        projectilePrefab: _defaultProjPrefab,
        numberOfProj: 5,
        projSpeed: 3,
        spawnRadius: 1f,
        angle: 0f,
        angleStep: 90);
}
