using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorDeath : MonoBehaviour
{
    int deathCountt = 0;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Floor")
        {
            deathCountt++;
            Debug.Log("şubir");

            if(deathCountt==3)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    
}
