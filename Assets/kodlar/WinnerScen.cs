using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinnerScen : MonoBehaviour
{
    public Text tak�m1, tak�m2, tak�m3, tak�m4;
    public GameObject Tak�m1, Tak�m2, Tak�m3, Tak�m4;

    void Awake()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Tak�mSay�s�") == 1)
        {
            Tak�m3.gameObject.SetActive(false);
            Tak�m4.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Tak�mSay�s�") == 2)
        {
            Tak�m4.gameObject.SetActive(false);
        }

        tak�m1.text = PlayerPrefs.GetInt("Tak�m1").ToString();
        tak�m2.text = PlayerPrefs.GetInt("Tak�m2").ToString();
        tak�m3.text = PlayerPrefs.GetInt("Tak�m3").ToString();
        tak�m4.text = PlayerPrefs.GetInt("Tak�m4").ToString();
    }

    public void AnaMen�()
    {
        SceneManager.LoadScene(0);
    }
}
