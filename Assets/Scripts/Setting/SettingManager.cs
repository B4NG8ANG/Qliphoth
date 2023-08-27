using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightSlider;
    public GameObject volumeText;
    public GameObject brightText;
    public float initialValue = 0.5f;
    
    void Start()
    {
        volumeSlider.value = initialValue;
        brightSlider.value = initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
