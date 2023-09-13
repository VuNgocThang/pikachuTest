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


    private void Start()
    {
        origin = transform.position;
        CheckUpFirst();
        // CheckRightFirst();

    }

    bool CheckUpFirst()
    {
        if (origin.x == target.position.x)
        {
            for (Vector3 v = new Vector3(0, boxSize, 0); origin.y + v.y < target.position.y; v += v)
            {
                bool isHit = Physics.BoxCast(origin
                   , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                   , out hit, Quaternion.identity, v.magnitude);
                Debug.Log("up1");
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
        {
            for (Vector3 v = new Vector3(0, boxSize, 0); origin.y + v.y < 12; v += v)
            {
                // check up lan dau

                bool isHit = Physics.BoxCast(origin
                    , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                    , out hit, Quaternion.identity, v.magnitude);
                Debug.Log("up1");

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
                //new Vector3(v.x, v.y - target.position.y, v.z);
                // neu hit thi cast thang vao target
                isHit = Physics.BoxCast(origin + v + new Vector3(target.position.x - (origin + v).x, 0, 0)
                    , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(0, target.position.y - v.y, 0)
                    , out hit, Quaternion.identity, new Vector3(0, target.position.y - (origin + v).y, 0).magnitude);
                Debug.Log("up2");
                if (isHit)
                {
                    Debug.Log(" hmmm");
                    //Debug.Log("up2" + origin + v + new Vector3(target.position.x - (origin + v).x, 0, 0));
                    if (hit.collider.gameObject.transform == target)
                    {
                        Debug.Log(origin + " and " + v + " and " + new Vector3(target.position.x, v.y, target.position.z) + " and " + target.position);
                        return true;
                    }

                }
            }
        }

        return false;
    }

    /*bool CheckRightFirst()
    {
        // check 2 điểm nếu cùng y
        if (origin.y == target.position.y)
        {
            for (Vector3 v = new Vector3(boxSize, 0, 0); origin.x + v.x < target.position.x; v += v)
            {
                bool isHit = Physics.BoxCast(origin
                   , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                   , out hit, Quaternion.identity, v.magnitude);
                Debug.Log("right1");
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
        {
            for (Vector3 v = new Vector3(boxSize, 0, 0); origin.x + v.x < target.position.x; v += v)
            {
                // check right lan dau

                bool isHit = Physics.BoxCast(origin
                    , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), v
                    , out hit, Quaternion.identity, v.magnitude);
                Debug.Log("right1");

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

                Debug.Log("up1");

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

                // neu hit thi check right lan nua

                isHit = Physics.BoxCast(origin + v + new Vector3(0, target.position.y - (origin + v).y, 0)
                    , new Vector3(boxSize / 4f, boxSize / 4f, boxSize / 4f), new Vector3(1, 0, 0)
                    , out hit, Quaternion.identity, target.position.x - (origin + v).x);
                Debug.Log("right2");
                if (isHit)
                {
                    if (hit.collider.gameObject.transform == target)
                    {
                        Debug.Log(origin + " and " + v + " and " + new Vector3(target.position.x, v.y, target.position.z) + " and " + target.position);
                        return true;
                    }

                }
            }
        }

        return false;
    }*/


}
