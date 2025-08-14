using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Auth
{
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
            
                LoginResponse resp = JsonUtility.FromJson<LoginResponse>(json);
                PlayerPrefs.SetString("jwt_token", resp.access);
                PlayerPrefs.Save();
            
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
    
        public void OnRegisterButton()
        {
            // StartCoroutine mesmo que não precise enviar dados
            StartCoroutine(RegisterRedirect());
        }
    
        IEnumerator RegisterRedirect()
        {
            // Aqui você pode fazer alguma requisição ao backend, se precisar
            // Por enquanto, só simulamos um pequeno delay
            yield return null; // aguarda 1 frame

            // Redireciona para RegisterScene
            SceneManager.LoadScene("RegisterScene", LoadSceneMode.Single);
        }
    
    }
}