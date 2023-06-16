using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIFinal : MonoBehaviour
{
    public VideoPlayer m_video;
    public void BackMenu()
    {
        m_video.Stop();
        SceneManager.LoadScene("Introduction");
    }
}
