using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioSource m_effectSource;
    public AudioSource m_Menu;
    public AudioSource m_Map1_Music;
    public AudioSource m_Map2_Music;
    public AudioSource m_Map3_Music;
    public AudioClip m_xu;
    public AudioClip m_star;
    public AudioClip m_jump;
    public AudioClip m_run;
    public AudioClip m_die;
    public AudioClip m_henshin;
    public AudioClip m_shoot;
    public AudioClip m_fly;
    public AudioClip m_vacham;
    public AudioClip m_click;
    public AudioClip m_circle;
    public AudioClip m_brick;
    public AudioClip m_reduce;
    
    public void PlayMap1()
    {
        m_Map1_Music.Play();
    }
    public void PlayMap2()
    {
        m_Map2_Music.Play();
    }
    public void PlayMap3()
    {
        m_Map3_Music.Play();
    }
    public void StopMap1()
    {
        m_Map1_Music.Stop();
    }
    public void StopMap2()
    {
        m_Map2_Music.Stop();
    }
    public void StopMap3()
    {
        m_Map3_Music.Stop();
    }
    public void PlayMenu()
    {
        m_Menu.Play();
    }
    public void OffMenu()
    {
        m_Menu.Stop();
    }
    public void EffectXu()
    {
        m_effectSource.PlayOneShot(m_xu);
    }
    public void EffectJump()
    {
        m_effectSource.PlayOneShot(m_jump);
    }
    public void EffectStar()
    {
        m_effectSource.PlayOneShot(m_star);
    }
    public void EffectRun()
    {
        m_effectSource.PlayOneShot(m_run);
        
    }
    public void EffectDie()
    {
      m_effectSource.PlayOneShot(m_die);
    }
    public void EffectHenshin()
    {
        m_effectSource.PlayOneShot(m_henshin);
    }
    public void EffectShoot()
    {
        m_effectSource.PlayOneShot(m_shoot);
    }
    public void EffectFly()
    {
       m_effectSource.PlayOneShot(m_fly);
    }
    public void EffectVacham()
    {
       m_effectSource.PlayOneShot(m_vacham);
    }
    public void EffectClick()
    {
       m_effectSource.PlayOneShot(m_click);
    }
    public void EffectCircle()
    {
        m_effectSource.PlayOneShot(m_circle);
    }
    public void EffectBrick()
    {
        m_effectSource.PlayOneShot(m_brick);
    }
    public void EffectReduce()
    {
        m_effectSource.PlayOneShot(m_reduce);
    }
}
