using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Menu
{
    public class MenuPrincipalManager :  MonoBehaviour
    {
        //[SerializeField] private string nomeDoLevelDeJogo;
        [SerializeField] private GameObject painelMenuInicial;
        [SerializeField] private GameObject painelOpcoes;
        public void Jogar()
        {
            SceneManager.LoadScene("PrimeiraTelaJogo");
        }

        public void AbrirOpcoes()
        {
            painelMenuInicial.SetActive(false);
            painelOpcoes.SetActive(true);
        }

        public void FecharOpcoes()
        {
            painelOpcoes.SetActive(false);
            painelMenuInicial.SetActive(true);
        }

        public void SairDoJogo()
        {
            SceneManager.LoadScene("AuthScene");
        }
        
        public void OpenRanking()
        {
            SceneManager.LoadScene("RankingScene");
        }
    }
}