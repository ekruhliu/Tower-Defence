using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlay : MonoBehaviour
{
    private bool escMenuOn;
    [SerializeField] private GameObject EscMenu;
    [SerializeField] private GameObject ExitMenu;
    
    private void Awake()
    {
        EscMenu.SetActive(false);
        ExitMenu.SetActive(false);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !escMenuOn)
        {
            
            PauseGame();
            EscMenu.SetActive(true);
            escMenuOn = true;
            Debug.Log(escMenuOn);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escMenuOn)
        {
            ResumeGame();
            EscMenu.SetActive(false);
            escMenuOn = false;
            Debug.Log(escMenuOn);
        }
    }

    public void ResumeGame()
    {
        gameManager.gm.pause((false));
        EscMenu.SetActive(false);
        ExitMenu.SetActive(false);
        escMenuOn = false;
    }

    public void ExitGame()
    {
        EscMenu.SetActive(false);
        ExitMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        UnityEngine.Application.LoadLevel("ex00");
    }
    
    public void ResumeGameButton() { gameManager.gm.pause((false));}
    
    public void PauseGame() { gameManager.gm.pause(true); }
    
    public void Speed(float speed) { gameManager.gm.changeSpeed(speed); }
    
}
