using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public class AnaKod : MonoBehaviour
{
    public int TakýmSayýsý=0;
    public float zaman;
    public bool yaz = true;
    public GameObject GameOverPanel;
    public TextMeshProUGUI zaman_t;
    public TextMeshProUGUI skor_t;
    public TextMeshProUGUI Aranan_t;
    public TextMeshProUGUI Yasak1_t, Yasak2_t, Yasak3_t, Yasak4_t, Yasak5_t;
    public TextMeshProUGUI HangýTakým;
    public TextMeshProUGUI Takým1_t, Takým2_t, Takým3_t, Takým4_t;
    public GameObject Takým1, Takým2, Takým3, Takým4;

    public int skor;
    int Takým1Puan;
    int Takým2Puan;
    int Takým3Puan;
    int Takým4Puan;
    public string[] kelimeler;
    public List<string> kelimeler2;
  
    private AudioSource audioSource;
    public AudioClip winSaund;
    public AudioClip loseSaund;
    public AudioClip passSaund;

    Ses ses;

    void Awake()
    {
        DosyaOku();
        KelimeSeç();
        audioSource = GetComponent<AudioSource>();
        ses = GameObject.Find("Main Camera").GetComponent<Ses>();

        zaman = 60;
        zaman_t.text = "" + (int)zaman;
        if (PlayerPrefs.GetInt("TakýmSayýsý") == 1)
        {
            Takým3.gameObject.SetActive(false);
            Takým4.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("TakýmSayýsý") == 2)
        {
            Takým4.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        zaman -= Time.deltaTime;
        zaman_t.text = "" + (int)zaman;
        if (zaman<=0)
        {
            if (yaz == true)
            {
                PuanYazdýr();
                yaz = false;
            }
            skor = 0;
            skor_t.text = skor.ToString();
            Time.timeScale = 0;          
            GameOverPanel.SetActive(true);
            zaman_t.text = "" + (int)zaman;


        }
        else
        {
            GameOverPanel.SetActive(false);
        }
        if (TakýmSayýsý == 0)
        {
            HangýTakým.text = "1.TAKIM";
        }
        if (TakýmSayýsý == 1)
        {
            HangýTakým.text = "2.TAKIM";
        }
        if (TakýmSayýsý == 2)
        {
            HangýTakým.text = "3.TAKIM";
        }
        if (TakýmSayýsý == 3)
        {
            HangýTakým.text = "4.TAKIM";
        }
    }

    public void PuanYazdýr()
    {
            switch (TakýmSayýsý)
            {
                case 0:
                Takým1Puan += skor;
                Takým1_t.text = Takým1Puan.ToString();
                    break;
                case 1:
                Takým2Puan += skor;
                Takým2_t.text =Takým2Puan.ToString();
                    break;
                case 2:
                Takým3Puan += skor;
                Takým3_t.text = Takým3Puan.ToString();
                    break;
                case 3:
                Takým4Puan += skor;
                Takým4_t.text = Takým4Puan.ToString();
                    break;
            }
            
    }

    public void Geç()
    {
        if (zaman > 0)
        {
            skor += 10;
            skor_t.text = skor.ToString();
            audioSource.PlayOneShot(winSaund);
            KelimeSeç();
        }
       
    }
    
    public void Yanlýþ() 
    {
        if (zaman> 0)
        {
            skor -= 5;
            skor_t.text = skor.ToString();
            audioSource.PlayOneShot(loseSaund);
            KelimeSeç();
        }
       
    }

    public void Pass()
    {
        if (zaman > 0)
        {
            audioSource.PlayOneShot(passSaund);
            KelimeSeç();
        }
       
    }

    public void DosyaOku() 
    {
        TextAsset textAsset = (TextAsset)Resources.Load("tabu");
        kelimeler = Encoding.UTF8.GetString(textAsset.bytes).Split('\n');
        for (int i = 0; i <= kelimeler.Length; i+=6)
        {
            kelimeler2.Add(kelimeler[i]);
        }
    }

    public void KelimeSeç()
    {
        System.Random random = new System.Random();
        int randomsayý= random.Next(0,kelimeler2.Count);
        Aranan_t.text = kelimeler2[randomsayý];
        Yasak1_t.text = kelimeler[randomsayý * 6 + 1];
        Yasak2_t.text = kelimeler[randomsayý * 6 + 2];
        Yasak3_t.text = kelimeler[randomsayý * 6 + 3];
        Yasak4_t.text = kelimeler[randomsayý * 6 + 4];
        Yasak5_t.text = kelimeler[randomsayý * 6 + 5];
    }

    public void Devam()
    {
        TakýmSayýsý++;
        if (TakýmSayýsý>1&&PlayerPrefs.GetInt("TakýmSayýsý")==1)
        {
            TakýmSayýsý=0;
        }
        if (TakýmSayýsý > 2 && PlayerPrefs.GetInt("TakýmSayýsý") == 2)
        {
            TakýmSayýsý = 0;
        }
        if (TakýmSayýsý > 3 && PlayerPrefs.GetInt("TakýmSayýsý") == 3)
        {
            TakýmSayýsý = 0;
        }
        zaman = 60;
        ses.isPlaying = false;
        Time.timeScale = 1;
        yaz = true;
        KelimeSeç();
        
    }

    public void MaçýBitir()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Takým1", Takým1Puan);
        PlayerPrefs.SetInt("Takým2", Takým2Puan);
        PlayerPrefs.SetInt("Takým3", Takým3Puan);
        PlayerPrefs.SetInt("Takým4", Takým4Puan);
    }
}
