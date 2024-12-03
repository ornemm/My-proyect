using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayController : MonoBehaviour
{
    public GameObject howToPlayPanel;

    private void Start()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false); // Aseg�rate de que el panel est� oculto al principio
        }
    }

    public void ShowPanel()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
        // Cierra la escena de "C�mo Jugar" y vuelve al men� principal
        SceneManager.UnloadSceneAsync("HowToPlay");
    }
}
