using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIFinal : MonoBehaviour
{
    public VideoPlayer m_video;
    UISound m_sound;
    private void Start()
    {
        m_sound = FindObjectOfType<UISound>();
    }
    public void BackMenu()
    {
        m_video.Stop();
        m_sound.EffectClick();
        SceneManager.LoadScene("Introduction");
    }
}
