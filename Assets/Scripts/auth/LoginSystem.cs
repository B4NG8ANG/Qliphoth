using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
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

    // 회원가입 경고 텍스트 오브젝트
    public GameObject signUpWarningText;
    public GameObject signUpEmailWarningText;
    public GameObject signUpPasswordWarningText;
    public GameObject signUpUsernameWarningText;

    // 로그인 경고 텍스트 오브젝트
    public GameObject loginWarningText;
    // public GameObject signUpEmailWarningText;
    // public GameObject signUpPasswordWarningText;
    // public GameObject signUpUsernameWarningText;
    
    
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

    public async void OnSignUpButtonClick()
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
            if(await Create() == 0)
            {
                signUpButton.SetActive(false);
                signUpEmailObject.SetActive(false);
                signUpPasswordObject.SetActive(false);
                signUpNicknameObject.SetActive(false);
                signUpNicknameCheckButtonObject.SetActive(false);

                loginButton.SetActive(true);
                loginEmailObject.SetActive(true);
                loginPasswordObject.SetActive(true);
                signUpButton.SetActive(false);
            }

            else if(await Create() == 1)
            {
                signUpWarningText.SetActive(false);
                signUpEmailWarningText.SetActive(false);
                signUpPasswordWarningText.SetActive(true);
                signUpUsernameWarningText.SetActive(false);
                signUpPasswordWarningText.GetComponent<Text>().text = "※ 비밀번호를 최소 6자리로 설정 해주세요.";
            }

            else if(await Create() == 2)
            {
                signUpWarningText.SetActive(false);
                signUpEmailWarningText.SetActive(false);
                signUpPasswordWarningText.SetActive(false);
                signUpUsernameWarningText.SetActive(true);
                signUpUsernameWarningText.GetComponent<Text>().text = "※ 닉네임을 입력 해주세요.";
            }

            else if(await Create() == 3)
            {
                signUpWarningText.SetActive(true);
                signUpEmailWarningText.SetActive(false);
                signUpPasswordWarningText.SetActive(false);
                signUpUsernameWarningText.SetActive(false);
                signUpWarningText.GetComponent<Text>().text = "※ 회원가입이 취소 되었습니다.";
            }

            else if(await Create() == 4)
            {
                signUpWarningText.SetActive(true);
                signUpEmailWarningText.SetActive(false);
                signUpPasswordWarningText.SetActive(false);
                signUpUsernameWarningText.SetActive(false);
                signUpWarningText.GetComponent<Text>().text = "※ 회원가입이 실패 하였습니다.";
            }

            else if(await Create() == 5)
            {
                signUpWarningText.SetActive(false);
                signUpEmailWarningText.SetActive(false);
                signUpPasswordWarningText.SetActive(false);
                signUpUsernameWarningText.SetActive(true);
                signUpUsernameWarningText.GetComponent<Text>().text = "※ 닉네임 중복 체크 해주세요.";
            }

            else if(await Create() == 6)
            {
                signUpWarningText.SetActive(true);
                signUpEmailWarningText.SetActive(false);
                signUpPasswordWarningText.SetActive(false);
                signUpUsernameWarningText.SetActive(false);
                signUpWarningText.GetComponent<Text>().text = "※ 회원가입 중 에러가 발생하였습니다.";
            }
            

        }    
    }

    public async void OnLoginButtonClick()
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
            // Login이 정상적으로 되면 Main씬으로 이동
            if(await LogIn() == 0)
            {
                StartCoroutine(songManager.Instance.loginPlayRecordUpdate());
                SceneChangeEffectManager.instance.FadeToScene("Main");
            }

            // 로그인 에러 시 화면에 경고 노출
            else if(await LogIn() == 1)
            {
                loginWarningText.SetActive(true);
                loginWarningText.GetComponent<Text>().text = "※ 로그인이 취소 되었습니다.";
            }

            else if(await LogIn() == 2)
            {
                loginWarningText.SetActive(true);
                loginWarningText.GetComponent<Text>().text = "※ 로그인에 실패 하였습니다.";
            }
        }    
    }

    public void OnLogoutButtonClick()
    {
        LogOut();
        SceneChangeEffectManager.instance.FadeToScene("Title");
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

            signUpWarningText.SetActive(false);
            signUpEmailWarningText.SetActive(false);
            signUpPasswordWarningText.SetActive(false);
            signUpUsernameWarningText.SetActive(false);

            loginWarningText.SetActive(false);

            loginEmailObject.SetActive(false);
            loginPasswordObject.SetActive(false);
            signUpButton.SetActive(true);
            loginButton.SetActive(true);
        }    
    }


    public async Task<int> Create(){
        string e = signUpEmail.text;
        string p = signUpPassword.text;
        string n = signUpNickname.text;

        if(AuthManager.Instance.isCheckNickname)
        {
            return await AuthManager.Instance.Create(e,p,n);
        }

        else
        {
            //TODO: 닉네임 중복 체크 prompt 띄우기
            Debug.Log("닉네임 중복 체크 해주세요~~");

            return 5;
        }

        
    }

    public async Task<int> LogIn(){
        // Debug.Log(AuthManager.Instance.UserId);
        return await AuthManager.Instance.LogIn(loginEmail.text, loginPassword.text);
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
