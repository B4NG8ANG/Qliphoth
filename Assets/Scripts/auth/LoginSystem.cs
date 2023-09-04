using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoginSystem : MonoBehaviour
{
    // 회원가입, 로그인 시 사용하는 값에 접근할 InputField
    public InputField signUpEmail;
    public InputField signUpPassword;
    public InputField signUpNickname;
    public InputField loginEmail;
    public InputField loginPassword;

    // UI 요소를 활성화, 비활성화 할때 사용할 게임 오브젝트
    public GameObject signUpEmailObject;
    public GameObject signUpPasswordObject;
    public GameObject signUpNicknameObject;
    public GameObject signUpNicknameCheckButtonObject;
    public GameObject loginEmailObject;
    public GameObject loginPasswordObject;
    public GameObject signUpButton;
    public GameObject loginButton;
    public GameObject authPanel;
    public GameObject logoImage;
    public GameObject authButton;
    
    
    // public TMP_Text outputText;
    // public TMP_Text LogInOutBtnText;

    void Start()
    {
        AuthManager.Instance.LoginState += OnChangeState;
        AuthManager.Instance.init();
    }

    private void OnChangeState(bool sign){
        // string text = sign ? "LOGIN" : "LOGOUT";
        // outputText.text = text;
        
        if(sign) {
            // outputText.text = AuthManager.Instance.UserName;
            // LogInOutBtnText.text = "LOGOUT";
            Debug.Log(AuthManager.Instance.UserName+"(으)로 로그인");
        }else{
            // outputText.text = "";
            // LogInOutBtnText.text = "LOGIN";
        }
        
    }

    public void OnSignUpButtonClick()
    {
        // SignUp 버튼을 클릭하였을때 Login 버튼이 활성화 되어있다면 회원가입 UI 노출
        if(loginButton.activeSelf)
        {
            signUpEmailObject.SetActive(true);
            signUpPasswordObject.SetActive(true);
            signUpNicknameObject.SetActive(true);
            signUpNicknameCheckButtonObject.SetActive(true);
            loginButton.SetActive(false);
        }
        // SignUp 버튼을 클릭하였을때 회원가입 UI가 노출 되어 있었다면 회원가입 실행
        else
        {
            Create();
        }    
    }

    public void OnLoginButtonClick()
    {
        // Login 버튼을 클릭하였을때 SignUp 버튼이 활성화 되어있다면 로그인 UI 노출
        if(signUpButton.activeSelf)
        {
            loginEmailObject.SetActive(true);
            loginPasswordObject.SetActive(true);
            signUpButton.SetActive(false);
        }
        // Login 버튼을 클릭하였을때 로그인 UI가 노출 되어 있었다면 로그인 실행
        else
        {
            LogIn();
        }    
    }

    public void OnExitButtonClick()
    {
        // Exit 버튼을 클릭하였을때 회원가입 UI와 로그인 UI가 모두 비활성화 되어 있었다면 패널 비활성화 후 타이틀 화면으로 돌아감
        if(signUpButton.activeSelf && loginButton.activeSelf)
        {
            authPanel.SetActive(false);
            logoImage.SetActive(true);
            authButton.SetActive(true);
        }
        // Exit 버튼을 클릭하였을때 회원가입 UI와 로그인 UI가 둘중 하나가 활성화 되어 있었다면 이전 단계로 돌아감
        else
        {
            signUpEmailObject.SetActive(false);
            signUpPasswordObject.SetActive(false);
            signUpNicknameObject.SetActive(false);
            signUpNicknameCheckButtonObject.SetActive(false);
            loginEmailObject.SetActive(false);
            loginPasswordObject.SetActive(false);
            signUpButton.SetActive(true);
            loginButton.SetActive(true);
        }    
    }


    public void Create(){
        string e = signUpEmail.text;
        string p = signUpPassword.text;
        string n = signUpNickname.text;

        if(AuthManager.Instance.isCheckNickname){
            AuthManager.Instance.Create(e,p,n);
        }else{
            //TODO: 닉네임 중복 체크 prompt 띄우기
            Debug.Log("닉네임 중복 체크 해주세요~~");
        }
        
    }

    public void LogIn(){
        // Debug.Log(AuthManager.Instance.UserId);
        AuthManager.Instance.LogIn(loginEmail.text, loginPassword.text);
    }

    public void LogOut(){
        AuthManager.Instance.logOut();
    }

    public void CheckNickname(){
        StaticCoroutine.DoCoroutine(AuthManager.Instance.CheckDuplicationNickname(signUpNickname.text));

    }

    public void ValueChange(){
        AuthManager.Instance.isCheckNickname = false;
    }
    
}
