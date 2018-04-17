using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreatHitter : MonoBehaviour
{
    bool m_greathit;

    GameObject m_note;

    [SerializeField]
    ScoreHandler m_score;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            m_note = collision.gameObject;
            m_greathit = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            m_greathit = false;
        }
    }

    public bool HitIsGreat()
    {
        return m_greathit;
    }
}
