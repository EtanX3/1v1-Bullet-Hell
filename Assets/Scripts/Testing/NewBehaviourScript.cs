using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  //  [SerializeField, Min(1)] private int _numberOfProj;
    //[SerializeField, Min(0)] private float _projSpeed;
    //[SerializeField] private GameObject _projPrefab;
    //[SerializeField, Range(0, 2)] private float _spawnradius;

    private Vector3 _playerPos;
    [SerializeField] GameObject _aim;
    [SerializeField] private Vector3 aimpos;
    private void Update()
    {
        _playerPos = this.transform.position;
        aimpos = _aim.transform.position;
        if (Input.GetKeyUp(KeyCode.J))
        { StartCoroutine(SpawnProjectiles(AttackLibrary.Three360())); }
        if(Input.GetKeyUp(KeyCode.Space))
            { StartCoroutine(SpawnProjectiles(AttackLibrary.OneForward())); }
    }

    IEnumerator SpawnProjectiles(AttackTemplate template)
    {
        yield return new WaitForSeconds(.1f);
        // automatically spread the total number of shots evenly around the object
        //change this to start at the aimpos and find angle in both directions from that point rather than draw a circle around the object
        float angleStep = 360 / template.Number;
        //current spawn angle
        float angle = 22.5f;
        //the transform's up angle,
        //used to make spawn position relative to the transform's rotation
        float transformUpAngle = Mathf.Atan2((aimpos.x - _playerPos.x), (aimpos.y - _playerPos.y));
        //cache pi times 2
        float pix2 = Mathf.PI * 2;

        for(int i = 0; i < template.Number; i++)
        {
            //calculate spawn position in world space (not transform-relaive)
            Vector2 startPosition = new Vector2(
                Mathf.Sin(((angle * Mathf.PI) / 180) + transformUpAngle),
                Mathf.Cos(((angle * Mathf.PI) / 180) + transformUpAngle));
           
            //make the spawn position relative to the transform, add buffer
            Vector2 relativeStartPos =
                (Vector2)_playerPos + startPosition * template.Radius;
            //calculate Z rotation to make projectiles face right direction
            float rotationZ = (360 - angle) - (angle * pix2 + transformUpAngle) * Mathf.Rad2Deg;
            //calculate the movement direction plus speed for this projectile
            Vector2 shotmovementvector =
                (relativeStartPos - (Vector2)_playerPos).normalized * template.Speed *-1;
            //instantiate proj at relative pos, and set velocity
            Instantiate(template.Prefab, relativeStartPos, Quaternion.Euler(0, 0, rotationZ))
                .GetComponent<Rigidbody>().velocity = shotmovementvector;

            //increment the current angle ready for next projectile spawn
            angle += angleStep;
            
        }
    }
    private void SpreadShot(AttackTemplate template)
    {
        //define start point of the circle as the line between both players
        //???

        //for each projectile, until reaching max number of projectiles, add angle to 
        for(int i = 0; i < template.Number; i++)
        {

        }
    }

}
