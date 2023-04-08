using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayfabControls : MonoBehaviour
{
    [SerializeField] GameObject signupTab, loginTab, startPanel;
    public TMP_Text username, userEmail, userPassword, userEmailLogin, userPasswordLogin, errorSignUp, errorLogin;
    string encryptedPassword;

    public void SignUpTab()
    {
        signupTab.SetActive(true);
        loginTab.SetActive(false);
    }

    public void LoginTab()
    {
        signupTab.SetActive(false);
        loginTab.SetActive(true);
    }

    public void SignUp()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail.text.Remove(userEmail.text.Length - 1), Password = userPassword.text.Remove(userPassword.text.Length - 1), Username = username.text.Remove(username.text.Length - 1) };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterError);
    }

    public void RegisterSuccess(RegisterPlayFabUserResult result)
    {
/*        UserInfo.instance.UserName = username.text.Remove(username.text.Length - 1);
        UserInfo.instance.EmailID = userEmailLogin.text.Remove(userEmailLogin.text.Length - 1);*/
        StartGame();
    }

    public void RegisterError(PlayFabError error)
    {
        errorSignUp.text = error.GenerateErrorReport();
    }

    public void Login()
    {
        //var request = new LoginWithEmailAddressRequest { Email = "aryan@aryan.com", Password = "123456" };
        //Debug.Log(userEmailLogin.text + " " + userPasswordLogin.text);
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin.text.Remove(userEmailLogin.text.Length - 1), Password = userPasswordLogin.text.Remove(userPasswordLogin.text.Length - 1) };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginError);
    }

    public void LoginSuccess(LoginResult result)
    {
/*        UserInfo.instance.UserName = result.InfoResultPayload.AccountInfo.Username;
        UserInfo.instance.EmailID = userEmailLogin.text.Remove(userEmailLogin.text.Length - 1);*/
        StartGame();
    }

    public void LoginError(PlayFabError error)
    {
        errorLogin.text = error.GenerateErrorReport();
    }

    public void StartGame()
    {
        errorLogin.text = "";
        startPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

}