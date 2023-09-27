using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using System;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class AuthManager
{
    //싱글톤
    private static AuthManager instance = null;
    public bool isCheckNickname = false;

    public static AuthManager Instance{
        get {
            if(instance == null){
                instance = new AuthManager();
            }

            return instance;
        }
    }
    private FirebaseAuth auth;
    private FirebaseUser user;

    public string UserId => user != null ? user.UserId : null;
    public string UserName => user != null ? user.DisplayName : null;
    public bool isLogIn => user != null;
    public Action<bool> LoginState;

    public void RegisterInDB(string user_id, string nickname){
        StaticCoroutine.DoCoroutine(UnityWebRequestPOST(user_id,nickname));
    }

    public async Task<int> Create(string email, string password, string nickname){
        // Test();
        if(password.Length < 6){
            Debug.Log("※ 비밀번호를 최소 6자리로 설정 해주세요.");
            return 1;
        }
        if(nickname == ""){ 
            Debug.Log("※ 닉네임을 입력 해주세요.");
            return 2;
        }

        try
        {
            Firebase.Auth.AuthResult result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            user = result.User;

            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                DisplayName = nickname,
                // PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
            };
            int errorCode =  await user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled) {
                    //회원가입이 취소 됐을때
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return 3;
                }
                if (task.IsFaulted) {
                    // 회원가입이 실패 했을때
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return 4;
                }

                Debug.Log("User profile updated successfully.");
                return 0;
                
            });

            if (errorCode > 0)
            {
                return errorCode;
            }

            RegisterInDB(user.UserId, nickname);
            isCheckNickname = false;
        }
        catch (System.Exception)
        {
            Debug.LogError("회원가입을 취소하거나 실패하였습니다");
            //throw;
            return 6;
        }

        return 0;
        
    }
    // Update is called once per frame
    public void init(){
        Debug.Log("init");
        //최초 인스턴스 불러옴
        auth = FirebaseAuth.DefaultInstance;

        //초기화 시 이전 로그인 정보 날림
        // if(auth.CurrentUser != null){
        //     Debug.Log("로그아웃@@@");
        //     logOut();
        // }

        //계정상태가 바뀔 때 호출되는 eventHandler
        auth.StateChanged += onChanged;

        
    }

    private void onChanged(object sender, EventArgs e){
        if(auth.CurrentUser != user){
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);

            //로그아웃
            if(!signed && user != null){
                Debug.Log("로그아웃");
                user = null;
                LoginState?.Invoke(false);
            }

            //계정이 바뀐 상태
            user = auth.CurrentUser;
            if(signed){
                Debug.Log("로그인");
                LoginState?.Invoke(true);
            }
        }
    }

    public void logOut(){
        auth.SignOut();
    }

    public async Task<int> LogIn(string email, string password){
        return await auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if(task.IsCanceled){
                Debug.Log("로그인 취소");
                Debug.Log(task.Exception);
                return 1;
            }
            if(task.IsFaulted){
                Debug.Log("로그인 실패");
                Debug.Log(task.Exception);
                return 2;
            }

            AuthResult result = task.Result;
            FirebaseUser newuser = result.User;

            return 0;
        });
    }

    IEnumerator UnityWebRequestPOST(string user_id, string nickname){
        Debug.Log("회원가입중...");
        string url = Constants.HOST+"create";
        WWWForm form = new WWWForm();

        form.AddField("user_id", user_id);
        form.AddField("nickname", nickname);

        UnityWebRequest www = UnityWebRequest.Post(url, form);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();

        if(www.error == null){
            logOut();
            Debug.Log(www.downloadHandler.text);
            Debug.Log("회원가입 완료");
        }
        else{
            //TODO: firebase회원 삭제
            Debug.Log(www.error);
        }

        www.Dispose();
    }

    public IEnumerator CheckDuplicationNickname(string nickname){
        string url = Constants.HOST+"nick/"+nickname;
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Get(url);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();

        if(www.error == null){
            Debug.Log(www.downloadHandler.text);
            isCheckNickname = true;
        }
        else{
            Debug.Log("닉네임이 중복됨");
            isCheckNickname = false;
        }

        www.Dispose();
    }
}


