using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControl : MonoBehaviour
{
    public GameObject m_snow;
    public GameObject m_mario;
    public float spawn_time;
    float m_time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_time -= Time.deltaTime;
        if (m_time <= 0)
        {
            SpawnBall();
            m_time = spawn_time;
        }
    }

    private void SpawnBall()
    {
        Vector2 spawnSnow = new Vector2(UnityEngine.Random.Range(m_mario.transform.localPosition.x - 8,
            m_mario.transform.localPosition.x + 8), m_mario.transform.localPosition.y + 8);

        Instantiate(m_snow, spawnSnow, Quaternion.identity);
    }
}
