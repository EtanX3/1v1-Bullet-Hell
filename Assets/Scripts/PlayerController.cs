using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public Transform _projectile1;
    public Transform _projectile2;
    private CharacterController controller;
    private Vector3 playerVelocity;
   [SerializeField] private float playerSpeed = 2.0f;
    private Vector2 move;
    private bool attacking;

    public Transform reticle;
    public BulletSpawner spawner;
    public RadialBulletController radialAttack;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        move = new Vector2(movement.x, movement.y);
    }
    public void OnAttack1(InputAction.CallbackContext context)
    {
        attacking = context.action.triggered;
        if (attacking)
        {
            /*
            Transform bulletTransform = Instantiate(_projectile1, reticle.transform.position, Quaternion.identity);
            Vector3 shootDir = ((transform.position - bulletTransform) * -1).normalized;
            bulletTransform.GetComponent<Bullet>().Setup(shootDir);
            */
            Vector3 shootDir = ((transform.position - reticle.transform.position)* -1).normalized;

            spawner._spawnerType = BulletSpawner.SpawnerType.Straight;
            spawner.Fire(shootDir);
        }
    }
    public void OnAttack2(InputAction.CallbackContext context)
    {
        attacking = context.action.triggered;
        if (attacking)
        {
            Vector3 shootDir = ((transform.position - reticle.transform.position) * -1).normalized;
            radialAttack.SpawnProjectile(5);
        }

    }

    void Update()
    {
        controller.Move(move * Time.deltaTime * playerSpeed);
        controller.Move(playerVelocity * Time.deltaTime);

        //bind player movement to camera bounds
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //how to set up the attack stuffs: scriptable object that holds fields for attack1, 2, etc.
    //Fill those with scripts that dictate how projectiles are spawned (likely using interface so they can all be activated by playercontroller w/ same method)
    //playercontroller has field for scriptable object, and when doing actions, tells scriptable to fire attacks, scriptable gets data from script, attack fires :D
}
