using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoginSystem : MonoBehaviour
{
    
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField nickname;

    public TMP_Text outputText;

    public TMP_Text LogInOutBtnText;

    // Start is called before the first frame update
    void Start()
    {
        AuthManager.Instance.LoginState += OnChangeState;
        AuthManager.Instance.init();
    }

    private void OnChangeState(bool sign){
        // string text = sign ? "LOGIN" : "LOGOUT";
        // outputText.text = text;
        
        if(sign) {
            outputText.text = AuthManager.Instance.UserName;
            LogInOutBtnText.text = "LOGOUT";
            Debug.Log(AuthManager.Instance.UserName+"(으)로 로그인");
        }else{
            outputText.text = "";
            LogInOutBtnText.text = "LOGIN";
        }
        
    }

    public void Create(){
        string e = email.text;
        string p = password.text;
        string n = nickname.text;

        AuthManager.Instance.Create(e,p,n);
    }

    public void LogIn(){
        // Debug.Log(AuthManager.Instance.UserId);
        if(AuthManager.Instance.isLogIn) AuthManager.Instance.logOut();
        else AuthManager.Instance.LogIn(email.text, password.text);
    }

     public void LogOut(){
        AuthManager.Instance.logOut();
    }

}
