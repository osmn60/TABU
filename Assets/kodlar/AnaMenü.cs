using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class AnaMenü : MonoBehaviour
{
    public GameObject TakımPanelobj;
    public GameObject ÇıkışPanelobj;
    public GameObject Seçim;
    private AudioSource audioSource;
    public AudioClip buttonSound;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();

        ÇıkışPanelobj.SetActive(false);
        TakımPanelobj.SetActive(false);
        Seçim.SetActive(false);
    }

    public void TakımPanel()
    {
        audioSource.PlayOneShot(buttonSound);
        TakımPanelobj.SetActive(true);
        TakımPanelobj.transform.DOLocalMoveX(0, 0.7f);
    }

    public void TakımPanelİptal()
    {
        audioSource.PlayOneShot(buttonSound);
        TakımPanelobj.transform.DOLocalMoveX(1936, 0.7f);
    }

    public void ÇıkışPanel()
    {
        audioSource.PlayOneShot(buttonSound);
        ÇıkışPanelobj.SetActive(true);
    }

    public void ÇıkışPanelİptal()
    {
        audioSource.PlayOneShot(buttonSound);
        ÇıkışPanelobj.SetActive(false);
    }

    public void Çıkış()
    {
        audioSource.PlayOneShot(buttonSound);
        Application.Quit();
    }

    public void İkiTakım()
    {
        Seçim.SetActive(true);
        PlayerPrefs.SetInt("TakımSayısı", 1);
        audioSource.PlayOneShot(buttonSound);
        Seçim.transform.localPosition = new Vector3(Seçim.transform.localPosition.x, 1138, transform.localPosition.z);
    }

    public void ÜçTakım()
    {
        Seçim.SetActive(true);
        PlayerPrefs.SetInt("TakımSayısı", 2);
        audioSource.PlayOneShot(buttonSound);
        Seçim.transform.localPosition = new Vector3(Seçim.transform.localPosition.x, -3, transform.localPosition.z);

    }

    public void DörtTakım()
    {
        Seçim.SetActive(true);
        PlayerPrefs.SetInt("TakımSayısı", 3);
        audioSource.PlayOneShot(buttonSound);
        Seçim.transform.localPosition = new Vector3(Seçim.transform.localPosition.x, -1168, transform.localPosition.z);

    }

    public void SahneGeçiş()
    {
        audioSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene(1);
    }
}
