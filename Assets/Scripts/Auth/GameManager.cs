using UnityEngine;

namespace Auth
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public string accessToken; // Token JWT do login

        void Awake()
        {
            // Singleton: mantém entre cenas
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}