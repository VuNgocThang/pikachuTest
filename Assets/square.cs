using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class square : MonoBehaviour
{
    public float maxDistance = 10f;
    public float boxSize = 0.80f;
    public GameObject hitObject;
    public bool isHit;
    public float i;
    Vector3 origin;
    Vector3 direction;
    public RaycastHit hit;

    public Transform target;

    /* private void Start()
     {
         origin = transform.position;
         direction = transform.right;

         //for ( i = origin.x + boxSize; i < 10f; i += boxSize)
         //{
         //    isHit = Physics.BoxCast(new Vector3(i, origin.y, origin.z), transform.lossyScale / 2f, direction, out hit, transform.rotation, boxSize);


         //}
     }

     private void OnDrawGizmos()
     {


         *//*    bool isHit = Physics.BoxCast(origin, transform.lossyScale / 2f, direction, out hit, transform.rotation, maxDistance);
             if (isHit)
             {
                 Gizmos.color = Color.red;
                 Gizmos.DrawRay(origin, direction * hit.distance);
                 Gizmos.DrawWireCube(origin + direction * hit.distance, transform.lossyScale / 2f);
             }
             else
             {
                 Gizmos.color = Color.green;
                 Gizmos.DrawRay(origin, direction * hit.distance);
             }*//*

         if (isHit)
         {
             Gizmos.color = Color.red;
             Gizmos.DrawRay(new Vector3(i, origin.y, origin.z), direction * hit.distance);
             Gizmos.DrawWireCube(new Vector3(i, origin.y, origin.z) + direction * hit.distance, transform.lossyScale / 2f);
         }
         else
         {
             Gizmos.color = Color.green;
             Gizmos.DrawRay(new Vector3(i, origin.y, origin.z), direction * boxSize);
         }


     }*/
    private void Start()
    {
        origin = transform.position;
        Debug.Log(CheckUpFirst());
        //CheckRightFirst();

    }
    bool CheckUpFirst()
    {
        for (Vector3 v = new Vector3(0, boxSize, 0); origin.y + v.y < target.position.y; v += v)
        {
            // check up lan dau

            bool isHit = Physics.BoxCast(origin
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                , out hit, Quaternion.identity, v.magnitude);
            Debug.Log("up1");

            Debug.Log(isHit);
            if (isHit)
            {
                if (hit.collider.gameObject.transform == target)
                {
                    Debug.Log(origin + " and " + target.position);
                    return true;
                }
                else
                {
                    break;
                }
            }

            // neu hit thi check right

            isHit = Physics.BoxCast(origin + v
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(1, 0, 0)
                , out hit, Quaternion.identity, target.position.x - (origin + v).x);

            Debug.Log("right1");

            if (isHit)
            {
                if (hit.collider.gameObject.transform == target)
                {
                    Debug.Log(origin + " and " + v + " and " + target.position);

                    return true;
                }
                else
                {
                    Debug.Log(hit.collider.gameObject.name);
                    continue;
                }
            }

            // neu hit thi check up lan nua

            isHit = Physics.BoxCast(origin + v + new Vector3(target.position.x - (origin + v).x, 0, 0)
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(0, 1, 0)
                , out hit, Quaternion.identity, target.position.y - (origin + v).y);

            if (isHit)
            {
                //Debug.Log("up2" + origin + v + new Vector3(target.position.x - (origin + v).x, 0, 0));
                if (hit.collider.gameObject.transform == target)
                {
                    Debug.Log(origin + " and " + v + " and " + new Vector3(target.position.x, v.y, target.position.z) + " and " + target.position);
                    return true;
                }

            }
        }
        return false;
    }

    void CheckRightFirst()
    {
        /*   Debug.Log(origin);
           Debug.Log(target.position);*/
        for (Vector3 v = new Vector3(boxSize, 0, 0); origin.x + v.x < target.position.x; v += v)
        {
            Debug.Log(v);
            // check right lan dau
            bool isHit = Physics.BoxCast(origin
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                , out hit, Quaternion.identity, v.magnitude);

            Debug.Log("right1");
            Debug.Log(isHit);
            if (isHit)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.transform == target)
                {
                    Debug.Log(origin + " and " + target.position);
                    // Debug.Log("return true");
                    return;
                }
                else
                {
                    break;
                }
            }


        }
        //return false;
    }

}
