using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchFloor : MonoBehaviour
{
    //[SerializeField] GameObject gameObject1;
    //[SerializeField] GameObject gameObject2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Floor")
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("death works");
        SceneManager.LoadScene("GameOver");
    }


}
