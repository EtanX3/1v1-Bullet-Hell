using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LockOnArrow : MonoBehaviour
{
    public GameObject parent;
    private GameObject target;
    public List<GameObject> playerList;
    public float aimAngle;

    private void Start()
    {
        playerList = FindObjectsOfType<PlayerController>().Select(stat => stat.gameObject).ToList();
        parent = gameObject.GetComponentInParent<PlayerController>().gameObject;

        if (playerList.Contains(parent))
        {
            playerList.Remove(parent);
        }
    }
    private void Update()
    {
        Vector3 Look = transform.InverseTransformPoint(playerList[0].transform.position);
        aimAngle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, aimAngle);
        //transform.LookAt(new Vector2(playerList[0].transform.position.x, playerList[0].transform.position.y));
    }
}
