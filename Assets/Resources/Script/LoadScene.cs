using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    float delay = 1.5f;
    public string Nextmap;
    
    public MarioMove m_move;
    [SerializeField]
    public SaveMemory m_memory;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SetActive(false);
            m_memory.txt_Score = m_move.m_score;
            m_memory.txt_Star=m_move.m_star_henshin;
            m_memory.isNext = true;
            ModeSelect();
        }
    }

    private void ModeSelect()
    {
        StartCoroutine(LoadMap());
    }
    IEnumerator LoadMap()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Nextmap);
    }
}
