using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    [SerializeField]
    GameObject panelSettings;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle();
        }
    }

    void toggle()
    {
        bool cond = panel.activeSelf || panelSettings.activeSelf;

        if (!cond)
        {
            player.GetComponent<RotateCamera>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            player.GetComponent<RotateCamera>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            panelSettings.SetActive(false);

        }

        panel.SetActive(!cond);

    }

    public void ShowSettings()
    { 
        panel.SetActive(false);
        panelSettings.SetActive(true);
    }


}
