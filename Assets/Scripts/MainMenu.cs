using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel; // Asigna el panel desde el Inspector

    public void Play()
    {
        SceneManager.LoadScene("Level1");
        Game.obj.ResetGameState(); // Reset game state
    }

    public void HowToPlay()
    {
        // Mostrar el panel de "Cómo Jugar"
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        // Ocultar el panel de "Cómo Jugar"
        //howToPlayPanel.SetActive(false);
        SceneManager.LoadScene("MainMenuScene"); // Usa el nombre de la escena que desees cargar
    }

    public void Exit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}


