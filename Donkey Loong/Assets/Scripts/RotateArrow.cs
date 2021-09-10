using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour
{
    private float sinValue = 0f;
    private float increment = 2f;
    [SerializeField] bool donuyorum = true;

   

    // Start is called before the first frame update
    void Start()
    {
       // forOKUI = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (forOKUI.okUI==true) {
            if (donuyorum)
            {
                sinValue += increment * Time.deltaTime;

                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sin(sinValue) * 24));
            }
       // }
    }

    public void StopRotating()
    {
        increment = 0;
    }

    public void StartRotating()
    {
        increment = 2f;
    }
}
