using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;

    public static bool isWin;

    // Start is called before the first frame update
    void Start()
    {
        winMenu.SetActive(false);
        isWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            winMenu.SetActive(true);
            //tenemos que pausar el reloj del juego
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;
        }
    }
}
