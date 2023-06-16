using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIMenu : MonoBehaviour
{
    public GameObject m_video;
    public GameObject m_intro;
    public GameObject m_intro2;
    public GameObject m_menu;
    public VideoPlayer m_clip;
    UISound m_sound;
    private void Start()
    {
        m_sound= FindObjectOfType<UISound>();
        m_sound.PlayMenu();
    }

    public void LoadGame()
    {
        m_sound.EffectClick();
        m_sound.OffMenu();
        SceneManager.LoadScene("Map1");
    }
    public void ActiveVideo()
    {
        m_sound.OffMenu();
        m_sound.EffectClick();
        m_menu.SetActive(false);
        m_video.SetActive(true);
        m_clip.Play();
    }

    public void ActiveIntro()
    {
        m_clip.Stop();
        m_sound.EffectClick();
        m_sound.PlayMenu();
        m_video.SetActive(false);
        m_intro.SetActive(true);
    }
    public void ActiveIntro2()
    {
        m_sound.EffectClick();
        m_intro.SetActive(false);
        m_intro2.SetActive(true);
    }
}
