using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text textScore;

    public GameObject gameOverPanel;
    
    public void ShowGameOver()
    {
        Time.timeScale = 0; // Pausa el juego
        gameOverPanel.SetActive(true);
        textScore.text = (("Score: ") + FindAnyObjectByType<Game>().score).ToString();
    }

    public void ResetLevel()
    {
        Game.obj.ResetGameState(); // Reset game state
        Time.timeScale = 1; // Reanuda el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1; // Reanuda el juego
    }
}
