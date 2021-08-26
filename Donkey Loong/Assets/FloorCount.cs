using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorCount : MonoBehaviour
{
    int dead = 0;

    public GameObject PanelOne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Boy")
        {
            dead++;

            if(dead==4)
            {
                Debug.Log("ölüm başlar");
                StartCoroutine(StartDeath());
            }
        }
    }

    IEnumerator StartDeath()
    {
        PanelOne.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }
}
