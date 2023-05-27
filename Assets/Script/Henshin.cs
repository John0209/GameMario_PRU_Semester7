using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henshin : MonoBehaviour
{
   public Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    //biến thành mario Pink
   public IEnumerator Mario()
    {
        float late = 0.1f;
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 1);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 1);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
    }
   public IEnumerator MarioPink()
    {
        float late = 0.1f;
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
    }
   public IEnumerator MarioGreen()
    {
        float late = 0.1f;
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 1);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 1);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 1);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 1);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 0);
        yield return new WaitForSeconds(late);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("MarioSmall"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Pink"), 0);
        m_animator.SetLayerWeight(m_animator.GetLayerIndex("Green"), 1);
        yield return new WaitForSeconds(late);
    }

}
