using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectAttack_Attempt : MonoBehaviour
{
    public GameObject A;
    public GameObject B;

    public int amount;

    [ContextMenu("PlaceSpheres()")]
    public void DebugPlace()
    {
        PlaceSpheres(A.transform.position, B.transform.position, amount);
    }

    public void PlaceSpheres(Vector2 posA, Vector2 posB, int numberOfObjects)
    {
        // get circle center and radius
        var radius = Vector3.Distance(posA, posB) / 2f;
        var centerPos = (posA + posB) / 2f;

        // get a rotation that looks in the direction
        // posA -> posB
        var centerDirection = Quaternion.LookRotation((posB - posA).normalized);

        for (var i = 0; i < numberOfObjects; i++)
        {
            // Max angle is 180° (= Mathf.PI in rad) not 360° (= Mathf.PI * 2 in rad)
            //          |
            //          |    don't place the first object exactly on posA 
            //          |    but start already with an offset
            //          |    (remove the +1 if you want to start at posA instead)
            //          |               |
            //          |               |     don't place the last object on posB 
            //          |               |     but end one offset before
            //          |               |     (remove the +1 if you want to end 
            //          |               |     exactly a posB instead)
            //          |               |                       |
            //          V               V                       V
            var angle = Mathf.PI * (i + 1) / (numberOfObjects);
            var x = Mathf.Sin(angle) * radius;
            var y = Mathf.Cos(angle) * radius;
            var pos = new Vector2(x, y);
            // Rotate the pos vector according to the centerDirection
            pos = centerDirection * pos;

            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = centerPos + pos;
            sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
}
