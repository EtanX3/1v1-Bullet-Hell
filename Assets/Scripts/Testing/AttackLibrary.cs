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
        numberOfProj: 2,
        projSpeed: 9f,
        spawnRadius: 1f);
    public static AttackTemplate Three360() => new AttackTemplate(
        projectilePrefab: _defaultProjPrefab,
        numberOfProj: 8,
        projSpeed: 9f,
        spawnRadius: 1f);
}
