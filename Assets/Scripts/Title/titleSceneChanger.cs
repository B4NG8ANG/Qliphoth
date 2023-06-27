using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class titleSceneChanger : MonoBehaviour
{
    public void onTitleClick()
    {
        SceneManager.LoadScene("Main");
    }
}
