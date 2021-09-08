using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{
    public float dir;
    public int score = 0;
    public float force;
    [SerializeField] TMPro.TextMeshProUGUI force_txt;
    //[SerializeField] TMPro.TextMeshProUGUI score_txt;

    public Slider slider;
    public Color low;
    public Color High;
    public Vector3 Offset; 

    void Start()
    {
        //score_txt.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        force = 2 + Mathf.PingPong(Time.time * 10, 10);
        var force_string = "";
        for (int i=0; i<Mathf.FloorToInt(force); i++)
        {
            //buraya slider gelecek
            force_string += "I";
        }
        force_txt.text = force_string;
    }

    public void UpdateScore()
    {
        //score += 5;
        //score_txt.text = score.ToString();
    }

    public void SetForce(float force,float maxForce)
    {

    }
}
