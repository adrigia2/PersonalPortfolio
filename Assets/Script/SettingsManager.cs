using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    TMP_InputField m_InputField;

    public void changeFps()
    {

        int n = Application.targetFrameRate;
        if (int.TryParse(m_InputField.text, out n))
        {
            Application.targetFrameRate = n;
            Debug.Log("sono qui");

        }

    }

    public void changeResolution(string newResolution)
    {

        string[] resolution = newResolution.Split('x');

        int n1 = int.Parse(resolution[0]);
        int n2 = int.Parse(resolution[1]);



        Screen.SetResolution(n1, n2, true);
    }


}
