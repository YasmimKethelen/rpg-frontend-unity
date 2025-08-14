using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    [Header("Login Inputs")]
    public TMP_InputField loginUsername;
    public TMP_InputField loginPassword;
    public TMP_Text loginMessage;

    [Header("Register Inputs")]
    public TMP_InputField registerUsername;
    public TMP_InputField registerEmail;
    public TMP_InputField registerPassword;
    public TMP_InputField registerConfirmPassword;
    public TMP_Text registerMessage;

    private string loginUrl = "http://127.0.0.1:8000/api/auth/login/";
    private string registerUrl = "http://127.0.0.1:8000/api/auth/register/";

    #region LOGIN
    public void OnLoginButton()
    {
        StartCoroutine(LoginRequest());
    }

    IEnumerator LoginRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", loginUsername.text);
        form.AddField("password", loginPassword.text);

        UnityWebRequest www = UnityWebRequest.Post(loginUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            loginMessage.text = "Login realizado!";
            var json = www.downloadHandler.text;
            LoginResponse resp = JsonUtility.FromJson<LoginResponse>(json);

            PlayerPrefs.SetString("jwt_token", resp.access);
            PlayerPrefs.Save();

            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            loginMessage.text = $"Erro: {www.downloadHandler.text}";
        }
    }

    [System.Serializable]
    public class LoginResponse
    {
        public string access;
        public string refresh;
    }
    #endregion

    #region REGISTER
    public void OnRegisterButton()
    {
        if (registerPassword.text != registerConfirmPassword.text)
        {
            registerMessage.text = "Senhas não conferem!";
            return;
        }

        StartCoroutine(RegisterRequest());
    }

    IEnumerator RegisterRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", registerUsername.text);
        form.AddField("email", registerEmail.text);
        form.AddField("password", registerPassword.text);

        UnityWebRequest www = UnityWebRequest.Post(registerUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            registerMessage.text = "Cadastro realizado!";
            yield return new WaitForSeconds(0.5f); // pequena pausa
            ChangeUI.instance.SwitchScreen(); // volta para login
        }
        else
        {
            registerMessage.text = $"Erro: {www.downloadHandler.text}";
        }
    }
    #endregion
}

