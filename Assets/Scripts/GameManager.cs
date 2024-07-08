using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public List<PlayerInput> playerList = new List<PlayerInput>();
    public int playerID;

    [SerializeField] InputAction joinAction;
    [SerializeField] InputAction leaveAction;
    //EVENTS
    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    //INSTANCES
    public static GameManager instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
        spawnPoints = GameObject.FindGameObjectsWithTag("SP");
    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerList.Add(playerInput);
        playerID = playerList.Count + 1;
        if(PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
        }

    }
    void OnPlayerLeft(PlayerInput playerInput)
    {

    }

    void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);
    }
    void LeaveAction(InputAction.CallbackContext context)
    {

    }
}
