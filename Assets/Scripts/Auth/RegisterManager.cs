using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using Auth;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;
    public TMP_Text messageText;

    private string registerUrl = "http://127.0.0.1:8000/api/auth/register/";

    public void OnRegisterButton()
    {
        if (passwordInput.text != confirmPasswordInput.text)
        {
            messageText.text = "Senhas não conferem!";
            return;
        }

        StartCoroutine(RegisterRequest());
    }

    IEnumerator RegisterRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);
        form.AddField("email", emailInput.text);
        form.AddField("password", passwordInput.text);

        UnityWebRequest www = UnityWebRequest.Post(registerUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            messageText.text = "Cadastro realizado com sucesso!";
            SceneManager.LoadScene("LoginScene");
        }
        else
        {
            messageText.text = $"Erro: {www.downloadHandler.text}";
        }
    }

    public void OnBackToLoginButton()
    {
        SceneManager.LoadScene("LoginScene", LoadSceneMode.Single);
    }
}