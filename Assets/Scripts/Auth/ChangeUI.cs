using UnityEngine;

public class ChangeUI : MonoBehaviour
{
    #region Singleton
    public static ChangeUI instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // Inicializa painéis de forma segura
        if (loginScreenPanel != null && registerScreenPanel != null)
        {
            loginScreenPanel.SetActive(true);
            registerScreenPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("ChangeUI: Painéis não atribuídos no Inspector!");
        }
    }
    #endregion

    [Header("Painéis de Login e Registro")]
    public GameObject loginScreenPanel;
    public GameObject registerScreenPanel;

    private bool loginActive = true;

    public void SwitchScreen()
    {
        if (loginScreenPanel == null || registerScreenPanel == null) return;

        loginActive = !loginActive;
        loginScreenPanel.SetActive(loginActive);
        registerScreenPanel.SetActive(!loginActive);

        Debug.Log("Tela trocada. Login ativo? " + loginActive);
    }
}