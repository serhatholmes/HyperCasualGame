using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject camera1;

    public Transform target;

    public float smoothSpeed = 0.125f;

    void Start()
    {
        camera1 = GameObject.FindGameObjectWithTag("Camera");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camSpawn")
        {
            
        }

        else if(other.tag == "camFinish")
        {

        }
    }



}
