using System.Collections;
using Auth;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

namespace Ranking
{
    [System.Serializable]
    public class PlayerRanking
    {
        public int id;
        public int user;
        public string username;
        public int score;       // moedas
        public int posicao;     // posição no ranking
    }

    [System.Serializable]
    public class PlayerRankingList
    {
        public PlayerRanking[] players;
    }

    [System.Serializable]
    public class MyRanking
    {
        public int id;
        public int user;
        public string username;
        public int score;
        public int posicao;
    }

    public class RankingManager : MonoBehaviour
    {
        [Header("Top Players UI")]
        public TMP_Text player1Text;
        public TMP_Text player2Text;
        public TMP_Text player3Text;

        [Header("My Position UI")]
        public TMP_Text myPositionText;

        [Header("Panel UI")]
        public GameObject rankingPanel;

        [Header("API Config")]
        public string rankingUrl = "http://127.0.0.1:8000/api/auth/ranking/";
        public string myRankingUrl = "http://127.0.0.1:8000/api/auth/ranking/me/";

        private string accessToken;

        void Start()
        {
            // Pega token do GameManager ou PlayerPrefs
            accessToken = GameManager.Instance?.accessToken;
            if(string.IsNullOrEmpty(accessToken))
                accessToken = PlayerPrefs.GetString("jwt_token", "");
            Debug.Log("Token atual: " + accessToken);
            
            // Inicializa painel
            if(rankingPanel != null)
                rankingPanel.SetActive(true);

            // Carrega ranking
            LoadRanking();
        }

        public void LoadRanking()
        {
            if(string.IsNullOrEmpty(accessToken))
            {
                Debug.LogError("Token JWT vazio. Não é possível carregar o ranking.");
                return;
            }

            Debug.Log("Carregando ranking...");
            StartCoroutine(GetRanking());
            StartCoroutine(GetMyPosition());
        }

        public void CloseRanking()
        {
            if(rankingPanel != null)
                rankingPanel.SetActive(false);
        }

        public void GoToMenuScene()
        {
            SceneManager.LoadScene("MainMenu");
        }

        IEnumerator GetRanking()
        {
            Debug.Log("Disparando GET para ranking: " + rankingUrl);
            UnityWebRequest www = UnityWebRequest.Get(rankingUrl);
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);


            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Erro ao buscar ranking: " + www.error);
            }
            else
            {
                string json = www.downloadHandler.text;
                Debug.Log("Ranking JSON recebido: " + json);

                // Envolve o array em um objeto para JsonUtility
                string wrappedJson = "{ \"players\":" + json + "}";
                PlayerRankingList list = JsonUtility.FromJson<PlayerRankingList>(wrappedJson);

                if(list.players.Length > 0 && player1Text != null)
                    player1Text.text = $"#{list.players[0].posicao} {list.players[0].username} - {list.players[0].score} 💰";
                if(list.players.Length > 1 && player2Text != null)
                    player2Text.text = $"#{list.players[1].posicao} {list.players[1].username} - {list.players[1].score} 💰";
                if(list.players.Length > 2 && player3Text != null)
                    player3Text.text = $"#{list.players[2].posicao} {list.players[2].username} - {list.players[2].score} 💰";
            }
        }

        IEnumerator GetMyPosition()
        {
            Debug.Log("Disparando GET para minha posição: " + myRankingUrl);
            UnityWebRequest www = UnityWebRequest.Get(myRankingUrl);
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);

            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Erro ao buscar minha posição: " + www.error);
            }
            else
            {
                string json = www.downloadHandler.text;
                Debug.Log("Minha posição JSON: " + json);

                if(string.IsNullOrEmpty(json))
                {
                    Debug.LogWarning("Resposta vazia para minha posição.");
                    yield break;
                }

                MyRanking me = JsonUtility.FromJson<MyRanking>(json);

                if(myPositionText != null)
                    myPositionText.text = $"Você está na posição {me.posicao} ({me.username}) com {me.score} 💰";
            }
        }
    }
}
