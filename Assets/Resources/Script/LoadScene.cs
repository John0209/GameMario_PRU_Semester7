using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    float delay = 1.5f;
    public string Nextmap;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SetActive(false);
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
