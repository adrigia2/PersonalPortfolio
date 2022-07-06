using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject player;

    

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    GameObject winPanel;
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void showEnd()
    {
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void showEndWin()
    {
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Start()
    {
        player= GameObject.FindWithTag("Player");
    }

}
