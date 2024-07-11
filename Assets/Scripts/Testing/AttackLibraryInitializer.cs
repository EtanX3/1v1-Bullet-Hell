using System.Collections;
using UnityEngine;

public class AttackLibraryInitializer : MonoBehaviour
{
    //vars of same type as those needed by Attack Templates
    //from project files
    [SerializeField] private GameObject Prefab_default;
    [SerializeField] private GameObject Prefab_homingMissile;

    //on awake, call initialize for the attacklibrary
    void Awake() => AttackLibrary.Initialize(Prefab_default, Prefab_homingMissile);
}
