using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enterMain : MonoBehaviour
{
    public void onTitleClick()
    {
        SceneManager.LoadScene("Main");
    }
}
