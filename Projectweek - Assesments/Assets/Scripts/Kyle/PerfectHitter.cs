using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectHitter : MonoBehaviour
{
    bool m_perfecthit;

    GameObject m_note;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            m_note = collision.gameObject;
            m_perfecthit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            m_perfecthit = false;
        }
    }

    public bool HitIsPerfect()
    {
        return m_perfecthit;
    }
}
