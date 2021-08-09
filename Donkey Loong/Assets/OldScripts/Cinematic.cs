using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cinematic : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private Animator anim1;
    private Rigidbody rb1;
    private bool Walk = true;

     

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void OnCollisonExit(Collision other)
    {
        if (other.gameObject.tag == "Start")
        {
            anim1.Play("Walking");
            transform.DOMoveX(8, 2);
        }
        if (other.gameObject.tag == "Stop")
        {
            transform.DORotate(new Vector3(0, -90, 0), 0.5f, RotateMode.Fast).OnComplete(() =>
            {
                anim1.Play("Idle");
            });
        }
    }
}
