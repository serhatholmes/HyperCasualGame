using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCount : MonoBehaviour
{

    int countPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countPlayer==5)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            countPlayer++;
            Debug.Log("tutundu");
        }
    }
}
