using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerArrow : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;

    float smooth = 0.5f;

    private void Start()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Character, Time.deltaTime * smooth)
        rotateArrow();
    }

    private void Update()
    {
        
    }

    public void rotateArrow()
    {
        var yRotation = objB.transform.eulerAngles.y;

        objA.transform.Rotate(objA.transform.eulerAngles.x, yRotation, objA.transform.eulerAngles.z);
    }
}

// Vector3(336.622711,1.27116489,0)

/* movetowards , lookat , rotate, ui object in 3d - top . 
 */