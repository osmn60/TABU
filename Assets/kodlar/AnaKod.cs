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
    public int Tak�mSay�s�=0;
    public float zaman;
    public bool yaz = true;
    public GameObject GameOverPanel;
    public TextMeshProUGUI zaman_t;
    public TextMeshProUGUI skor_t;
    public TextMeshProUGUI Aranan_t;
    public TextMeshProUGUI Yasak1_t, Yasak2_t, Yasak3_t, Yasak4_t, Yasak5_t;
    public TextMeshProUGUI Hang�Tak�m;
    public TextMeshProUGUI Tak�m1_t, Tak�m2_t, Tak�m3_t, Tak�m4_t;
    public GameObject Tak�m1, Tak�m2, Tak�m3, Tak�m4;

    public int skor;
    int Tak�m1Puan;
    int Tak�m2Puan;
    int Tak�m3Puan;
    int Tak�m4Puan;
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
        KelimeSe�();
        audioSource = GetComponent<AudioSource>();
        ses = GameObject.Find("Main Camera").GetComponent<Ses>();

        zaman = 60;
        zaman_t.text = "" + (int)zaman;
        if (PlayerPrefs.GetInt("Tak�mSay�s�") == 1)
        {
            Tak�m3.gameObject.SetActive(false);
            Tak�m4.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Tak�mSay�s�") == 2)
        {
            Tak�m4.gameObject.SetActive(false);
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
                PuanYazd�r();
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
        if (Tak�mSay�s� == 0)
        {
            Hang�Tak�m.text = "1.TAKIM";
        }
        if (Tak�mSay�s� == 1)
        {
            Hang�Tak�m.text = "2.TAKIM";
        }
        if (Tak�mSay�s� == 2)
        {
            Hang�Tak�m.text = "3.TAKIM";
        }
        if (Tak�mSay�s� == 3)
        {
            Hang�Tak�m.text = "4.TAKIM";
        }
    }

    public void PuanYazd�r()
    {
            switch (Tak�mSay�s�)
            {
                case 0:
                Tak�m1Puan += skor;
                Tak�m1_t.text = Tak�m1Puan.ToString();
                    break;
                case 1:
                Tak�m2Puan += skor;
                Tak�m2_t.text =Tak�m2Puan.ToString();
                    break;
                case 2:
                Tak�m3Puan += skor;
                Tak�m3_t.text = Tak�m3Puan.ToString();
                    break;
                case 3:
                Tak�m4Puan += skor;
                Tak�m4_t.text = Tak�m4Puan.ToString();
                    break;
            }
            
    }

    public void Ge�()
    {
        if (zaman > 0)
        {
            skor += 10;
            skor_t.text = skor.ToString();
            audioSource.PlayOneShot(winSaund);
            KelimeSe�();
        }
       
    }
    
    public void Yanl��() 
    {
        if (zaman> 0)
        {
            skor -= 5;
            skor_t.text = skor.ToString();
            audioSource.PlayOneShot(loseSaund);
            KelimeSe�();
        }
       
    }

    public void Pass()
    {
        if (zaman > 0)
        {
            audioSource.PlayOneShot(passSaund);
            KelimeSe�();
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

    public void KelimeSe�()
    {
        System.Random random = new System.Random();
        int randomsay�= random.Next(0,kelimeler2.Count);
        Aranan_t.text = kelimeler2[randomsay�];
        Yasak1_t.text = kelimeler[randomsay� * 6 + 1];
        Yasak2_t.text = kelimeler[randomsay� * 6 + 2];
        Yasak3_t.text = kelimeler[randomsay� * 6 + 3];
        Yasak4_t.text = kelimeler[randomsay� * 6 + 4];
        Yasak5_t.text = kelimeler[randomsay� * 6 + 5];
    }

    public void Devam()
    {
        Tak�mSay�s�++;
        if (Tak�mSay�s�>1&&PlayerPrefs.GetInt("Tak�mSay�s�")==1)
        {
            Tak�mSay�s�=0;
        }
        if (Tak�mSay�s� > 2 && PlayerPrefs.GetInt("Tak�mSay�s�") == 2)
        {
            Tak�mSay�s� = 0;
        }
        if (Tak�mSay�s� > 3 && PlayerPrefs.GetInt("Tak�mSay�s�") == 3)
        {
            Tak�mSay�s� = 0;
        }
        zaman = 60;
        ses.isPlaying = false;
        Time.timeScale = 1;
        yaz = true;
        KelimeSe�();
        
    }

    public void Ma��Bitir()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Tak�m1", Tak�m1Puan);
        PlayerPrefs.SetInt("Tak�m2", Tak�m2Puan);
        PlayerPrefs.SetInt("Tak�m3", Tak�m3Puan);
        PlayerPrefs.SetInt("Tak�m4", Tak�m4Puan);
    }
}
