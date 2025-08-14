using UnityEngine;
using UnityEngine.SceneManagement;

namespace Auth
{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadSceneAndClearCanvas(string sceneName)
        {
            // 🔹 Força destruição de todos os Canvas na cena atual
            Canvas[] allCanvas = FindObjectsOfType<Canvas>(true); // (true) inclui objetos inativos
            foreach (Canvas c in allCanvas)
            {
                Destroy(c.gameObject);
            }

            // 🔹 Carrega a nova cena
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}