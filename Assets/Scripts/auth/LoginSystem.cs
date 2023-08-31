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

        if(AuthManager.Instance.isCheckNickname){
            AuthManager.Instance.Create(e,p,n);
        }else{
            //TODO: 닉네임 중복 체크 prompt 띄우기
            Debug.Log("닉네임 중복 체크 해주세요~~");
        }
        
    }

    public void LogIn(){
        // Debug.Log(AuthManager.Instance.UserId);
        if(AuthManager.Instance.isLogIn) AuthManager.Instance.logOut();
        else AuthManager.Instance.LogIn(email.text, password.text);
    }

     public void LogOut(){
        AuthManager.Instance.logOut();
    }

    public void CheckNickname(){
        StaticCoroutine.DoCoroutine(AuthManager.Instance.CheckDuplicationNickname(nickname.text));

    }

    public void ValueChange(){
        AuthManager.Instance.isCheckNickname = false;
    }
    
}
