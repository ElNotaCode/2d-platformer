using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    public static bool isDead;

    void Start()
    {
        gameOverMenu.SetActive(false);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            gameOverMenu.SetActive(true);
            //tenemos que pausar el reloj del juego
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;
        }

    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene("Level1");
    }

}
