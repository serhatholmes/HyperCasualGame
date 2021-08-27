using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour
{
    private float sinValue = 0f;
    private float increment = 0.07f;
    [SerializeField] bool donuyorum = true;

    Player forOKUI;

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
                sinValue += increment;

                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sin(sinValue) * 24));
            }
       // }
    }
}
