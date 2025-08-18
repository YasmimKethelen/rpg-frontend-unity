using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGameManager
{
    public class CutsceneManager : MonoBehaviour
    {
        public TextMeshProUGUI textoUI;   // Texto do diálogo
        public float tempoEntreFalas = 4f; // Tempo que cada fala fica na tela

        // Aqui colocamos o diálogo em ordem
        private string[] dialogos = new string[]
        {
            "[Professor-Gilberto]: Alunos, informo que o simulado final para conclusão do curso é amanhã! Espero que estejam preparados para mais esse desafio, não me decepcionem!",
            "[Personagem]: Nossa… tenho que revisar urgentemente tudo! Havia esquecido que a prova estava tão perto!",
            "[Giuli]: Calma, esquecer faz parte da emoção da reta final! Estudar com um pouco de pressão até me ajuda a focar melhor.",
            "[Yasmim]: Ih, lá vem ele com esse papo! Esse aí já devia estar dando aula com o professor Gilberto. Vive acertando tudo! Se eu tirar metade da sua nota, já tô comemorando com bolo e guaraná.",
            "[Giuli]: Que isso, só tento não surtar… muito.",
            "[Luan]: Então tá fazendo errado, porque surtar é meu plano A! Inclusive, se alguém achar minha calma por aí, favor devolver antes da prova!"
        };

        void Start()
        {
            StartCoroutine(MostrarDialogos());
        }

        IEnumerator MostrarDialogos()
        {
            foreach (string fala in dialogos)
            {
                textoUI.text = fala;
                yield return new WaitForSeconds(tempoEntreFalas);
            }
        
            SceneManager.LoadScene("MainMenu");
        }
    }
}