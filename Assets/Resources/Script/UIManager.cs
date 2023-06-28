using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text m_score;
    public Text m_star;
    MarioMove m_move;
    public GameObject m_lv2;
    public GameObject m_lv3;
    public GameObject m_over;
    public string txt_Map;
    [SerializeField]
    public SaveMemory m_load;
    UISound m_sound;
    private void Start()
    {
        m_move=FindObjectOfType<MarioMove>();
        //m_load=FindObjectOfType<SaveMemory>();
        m_sound= FindObjectOfType<UISound>();
        PlayMusicMap();
    }
    public void Exit()
    {
        m_load.isNext = true;
        SceneManager.LoadScene("Introduction");
    }
    public void GameOver()
    {
        m_sound.StopMap1();
        m_sound.StopMap2();
        m_sound.StopMap3();
        m_over.SetActive(true);
    }
    void PlayMusicMap()
    {
        switch (txt_Map)
        {
            case "Map1":
                m_sound.PlayMap1();
                break;
            case "Map2":
                m_sound.PlayMap2();
                break;
            case "Map3":
                m_sound.PlayMap3();
                break;

        }
    }
    public void Replay()
    {
        m_load.isNext=true;
        SceneManager.LoadScene(txt_Map);
       // PlayMusicMap();
    }
  
    public void SetTextScore(string text)
    {
        m_score.text = text;
    }
    public void SetTextStar(string text)
    {
        m_star.text = text;
    }
    public void Lv1()
    {
        m_move.henshin = true;
        m_move.level = 1;
    }
    public void Lv2()
    {
        m_move.henshin = true;
        m_move.level=2;
    }
    public void Lv3()
    {
        m_move.henshin = true;
        m_move.level = 3;
    }
    public void ActiveButtonLv2()
    {
        m_lv2.SetActive(true);
    }
    public void ActiveButtonLv3()
    {
        m_lv3.SetActive(true);
    }
    public void DisActiveButtonLv2()
    {
        m_lv2.SetActive(false);
    }
    public void DisActiveButtonLv3()
    {
        m_lv3.SetActive(false);
    }
}
