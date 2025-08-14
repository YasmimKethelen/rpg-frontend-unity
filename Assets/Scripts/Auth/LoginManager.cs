using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text messageText;

    private string loginUrl = "http://127.0.0.1:8000/api/auth/login/";

    public void OnLoginButton()
    {
        StartCoroutine(LoginRequest());
    }

    IEnumerator LoginRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);
        form.AddField("password", passwordInput.text);

        UnityWebRequest www = UnityWebRequest.Post(loginUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var json = www.downloadHandler.text;
            messageText.text = "Login realizado!";
            Debug.Log(json);

            // Parse JSON para pegar token
            LoginResponse resp = JsonUtility.FromJson<LoginResponse>(json);
            PlayerPrefs.SetString("jwt_token", resp.access);
            PlayerPrefs.Save();

            // Redirecionar para próxima cena
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            messageText.text = $"Erro: {www.downloadHandler.text}";
        }
    }

    [System.Serializable]
    public class LoginResponse
    {
        public string access; // depende do nome retornado no DRF
        public string refresh;
    }
}