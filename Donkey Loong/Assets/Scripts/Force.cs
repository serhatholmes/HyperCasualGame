using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{
    public float dir;
    public int score = 0;
    public float force;
    //[SerializeField] TMPro.TextMeshProUGUI force_txt;
    [SerializeField] Slider slider;
    private float sliderMin, sliderMax;
    [SerializeField] float sliderIncrement;
    //[SerializeField] TMPro.TextMeshProUGUI score_txt;

    public Color low;
    public Color High;
    public Vector3 Offset; 

    void Start()
    {
        if (slider != null)
        {
            sliderMin = slider.minValue;
            sliderMax = slider.maxValue;
        }

    }

    // Update is called once per frame
    void Update()
    {
        force = sliderMin + Mathf.PingPong(Time.time * sliderIncrement, sliderMax-sliderMin);

        if (slider != null)
        {
            slider.value = force;
        }
        
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
