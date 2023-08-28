using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using System;

public class AuthManager
{
    //싱글톤
    private static AuthManager instance = null;

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

    public void Create(string email, string password, string nickname){
        if(password.Length < 6){
            Debug.Log("비밀번호를 최소 6자리로 설정 해주세요");
        }
        if(nickname == ""){ 
            Debug.Log("닉네임을 설정해주세요");
            return;
        }
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if(task.IsCanceled){
                Debug.Log("회원가입 취소");
                return;
            }
            if(task.IsFaulted){
                Debug.Log("회원가입 실패");
                return;
            }

            
            AuthResult result = task.Result;
            user = result.User;

            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                DisplayName = nickname,
                // PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");
            });
            
            //가입 후 애매하게 로그인되서 로그아웃 처리.
            logOut();
            Debug.Log("회원가입 완료");
        });
    }
    // Update is called once per frame
    public void init(){
        //최초 인스턴스 불러옴
        auth = FirebaseAuth.DefaultInstance;

        //초기화 시 이전 로그인 정보 날림
        if(auth.CurrentUser != null){
            logOut();
        }

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

    public void LogIn(string email, string password){
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if(task.IsCanceled){
                Debug.Log("로그인 취소");
                return;
            }
            if(task.IsFaulted){
                Debug.Log("로그인 실패");
                return;
            }

            AuthResult result = task.Result;
            FirebaseUser newuser = result.User;
        });
    }

}
