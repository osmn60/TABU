using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinnerScen : MonoBehaviour
{
    public Text takým1, takým2, takým3, takým4;
    public GameObject Takým1, Takým2, Takým3, Takým4;

    void Awake()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("TakýmSayýsý") == 1)
        {
            Takým3.gameObject.SetActive(false);
            Takým4.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("TakýmSayýsý") == 2)
        {
            Takým4.gameObject.SetActive(false);
        }

        takým1.text = PlayerPrefs.GetInt("Takým1").ToString();
        takým2.text = PlayerPrefs.GetInt("Takým2").ToString();
        takým3.text = PlayerPrefs.GetInt("Takým3").ToString();
        takým4.text = PlayerPrefs.GetInt("Takým4").ToString();
    }

    public void AnaMenü()
    {
        SceneManager.LoadScene(0);
    }
}
