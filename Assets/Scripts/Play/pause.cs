using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
     public void onPauseButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
