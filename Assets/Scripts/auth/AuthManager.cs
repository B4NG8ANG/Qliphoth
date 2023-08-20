using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class AuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    // public InputField email;
    // public InputField email;

    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        if(user != null){
            Debug.Log(user);
        }else{
            Debug.Log("로그인필요");
        }
    }

    public void Create(){
        auth.CreateUserWithEmailAndPasswordAsync("test@naver.com", "123123").ContinueWith(task => {
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
            
            Debug.Log("회원가입 완료");
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void logOut(){
        auth.SignOut();
        Debug.Log("로그아웃");
    }

    public void LogIn(){
        auth.SignInWithEmailAndPasswordAsync("test@naver.com", "123123").ContinueWith(task => {
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
            Debug.Log("로그인 완료");
        });
    }

}
