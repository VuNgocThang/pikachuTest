using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class square : MonoBehaviour
{
    public float boxSize = 1.2f;
    public bool isHit;
    Vector3 origin;
    RaycastHit hit;

    float minX, minY;
    float maxX, maxY;
    private void Awake()
    {
        minX = 0; minY = 0;
        maxX = 10; maxY = 10;
    }
    public Transform target;


    private void Start()
    {
        origin = transform.position;
        //CheckUpFirst();
        CheckRightFirst();
    }

    /* bool CheckUpFirst()
     {
         if (origin.x == target.position.x)
         {
             for (Vector3 v = new Vector3(0, boxSize, 0); origin.y + v.y < target.position.y; v.y += boxSize)
             {
                 bool isHit = Physics.BoxCast(origin
                    , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                    , out hit, Quaternion.identity, v.magnitude);
                 if (isHit)
                 {
                     if (hit.collider.gameObject.transform != target)
                     {
                         return false;
                     }
                 }
             }
             return true;
         }
         else
         {
             for (Vector3 v = new Vector3(0, boxSize, 0); origin.y + v.y < maxY + 2 * boxSize; v.y += boxSize)
             {
                 // check up lan dau

                 bool isHit = Physics.BoxCast(origin
                     , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                     , out hit, Quaternion.identity, v.magnitude);
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

                 if (isHit)
                 {
                     if (hit.collider.gameObject.transform == target)
                     {
                         Debug.Log("dmdmdm");
                         return true;
                     }
                     else
                     {
                         continue;
                     }
                 }

                 // neu hit thi check thẳng vào target lan nua
                 isHit = Physics.BoxCast(origin + v + new Vector3(target.position.x - (origin + v).x, 0, 0)
                     , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(0, target.position.y - v.y, 0)
                     , out hit, Quaternion.identity, new Vector3(0, target.position.y - (origin + v).y, 0).magnitude);
                 if (isHit)
                 {
                     //Debug.Log("up2" + origin + v + new Vector3(target.position.x - (origin + v).x, 0, 0));
                     if (hit.collider.gameObject.transform == target)
                     {
                         //Debug.Log(origin + " and " + new Vector3(origin.x + v.x, origin.y + v.y, origin.z + v.z) + " and " + new Vector3(target.position.x, v.y, target.position.z) + " and " + target.position);

                         Debug.Log(origin + " --> " + new Vector3(origin.x + v.x, origin.y + v.y, origin.z + v.z) + " --> " + new Vector3(target.position.x, origin.y + v.y, origin.z + v.z) + " --> " + target.position);

                         return true;
                     }

                 }
             }
         }

         return false;
     }*/

    bool CheckRightFirst()
    {
        // check 2 điểm nếu cùng y
        /*if (origin.y == target.position.y)
        {
            for (Vector3 v = new Vector3(boxSize, 0, 0); origin.x + v.x < target.position.x; v.x += boxSize)
            {
                bool isHit = Physics.BoxCast(origin
                   , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                   , out hit, Quaternion.identity, v.magnitude);
                if (isHit)
                {
                    if (hit.collider.gameObject.transform != target)
                    {
                        return false;
                    }
                }
            }
            Debug.Log(origin + " and " + target.position);
            return true;
        }
        else
        {*/
        for (Vector3 v = new Vector3(boxSize, 0, 0); origin.x + v.x <= maxX + 2 * boxSize; v.x += boxSize)
        {
            Debug.Log(origin.x + v.x);
            Debug.Log(v);
            bool isHit = Physics.BoxCast(origin
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                , out hit, Quaternion.identity, v.magnitude);

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

            // neu hit thi check up

            isHit = Physics.BoxCast(origin + v
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(0, 1, 0)
                , out hit, Quaternion.identity, target.position.y - (origin + v).y);

            if (isHit)
            {
                Debug.Log(hit.collider.transform.name);
                if (hit.collider.gameObject.transform == target)
                {
                    Debug.Log(origin + " --> " + new Vector3(origin.x + v.x, origin.y + v.y, origin.z + v.z) + " --> " + target.position);

                    return true;
                }
                else
                {
                    continue;
                }
            }

            isHit = Physics.BoxCast(origin + v + new Vector3(0, target.position.y - (origin + v).y, 0)
                , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(target.position.x - v.x, 0, 0)
                , out hit, Quaternion.identity, new Vector3(target.position.x - (origin + v).x, 0, 0).magnitude);
            if (isHit)
            {
                if (hit.collider.gameObject.transform == target)
                {
                    Debug.Log(origin + " --> " + new Vector3(origin.x + v.x, origin.y + v.y, origin.z + v.z) + " --> " + new Vector3(origin.x + v.x, target.position.y, origin.z + v.z) + " --> " + target.position);
                    return true;
                }
            }
            // }
        }

        return false;
    }

    bool CheckDownFirst()
    {


        return false;
    }
}
