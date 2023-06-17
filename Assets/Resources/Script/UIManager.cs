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
    private void Start()
    {
        m_move=FindObjectOfType<MarioMove>();
        //m_load=FindObjectOfType<SaveMemory>();
    }
    public void Exit()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void GameOver()
    {
        m_over.SetActive(true);
    }
    public void Replay()
    {
        m_load.isNext=true;
        SceneManager.LoadScene(txt_Map);
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
