using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencingController : MonoBehaviour
{
    Animator m_anim;

    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    public void PlayRandomBlock()
    {
        int r = Random.Range(0,4);

        switch(r)
        {
            case 0:
                m_anim.Play("Player_Blocks");
                break;

            case 1:
                m_anim.Play("Player_Blocks_1");
                break;

            case 2:
                m_anim.Play("Player_Blocks_2");
                break;

            case 3:
                m_anim.Play("Player_Blocks_3");
                break;
        }
    }

    public void PlayRandomPlayerHitted()
    {
        int r = Random.Range(0, 3);

        switch (r)
        {
            case 0:
                m_anim.Play("Player_Hitted_0");
                break;

            case 1:
                m_anim.Play("Player_Hitted_1");
                break;

            case 2:
                m_anim.Play("Player_Hitted_2");
                break;
        }
    }

    public void PlayPlayerDeath()
    {
        m_anim.Play("PlayerLoses");
    }

    public void PlayEnemyDeath()
    {
        m_anim.Play("AILoses");
    }
}
