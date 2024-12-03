using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayController : MonoBehaviour
{
    public GameObject howToPlayPanel;

    private void Start()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false); // Asegúrate de que el panel esté oculto al principio
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
        // Cierra la escena de "Cómo Jugar" y vuelve al menú principal
        SceneManager.UnloadSceneAsync("HowToPlay");
    }
}
