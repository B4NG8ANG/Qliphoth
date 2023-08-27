using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTestButtonClick()
    {
        //SceneManager.LoadScene("Play");
        SceneChangeEffectManager.instance.FadeToScene("LoginTest");
    }
}
