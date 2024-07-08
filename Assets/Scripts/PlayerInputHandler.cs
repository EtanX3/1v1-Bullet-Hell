using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject playerPrefab;
    PlayerController _playerController;
    public int playerID;
    public void SpawnPlayer()
    {
        if(playerPrefab != null)
        {
            _playerController = GameObject.Instantiate(playerPrefab, transform.position, transform.rotation).GetComponent<PlayerController>();

            transform.parent = _playerController.transform;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _playerController.OnMove(context);
    }
    public void OnAttack1(InputAction.CallbackContext context)
    {
        _playerController.OnAttack1(context);
    }
    public void OnAttack2(InputAction.CallbackContext context)
    {
        _playerController.OnAttack2(context);
    }
}
