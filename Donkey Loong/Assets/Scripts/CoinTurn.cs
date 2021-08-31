using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinTurn : MonoBehaviour
{
    public float turnSpeed = 90f;

    //GoldScore goldPlus;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed* Time.deltaTime);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boy")
        {
            //Destroy(gameObject);
        }
    }


}
