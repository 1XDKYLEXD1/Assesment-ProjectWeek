using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadHitter : MonoBehaviour
{
    bool m_badhit;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            m_badhit = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            m_badhit = false;
        }
    }

    public bool NoteIsInBadArea()
    {
        if(m_badhit == true)
        {
            return m_badhit;
        }
        else
        {
            return m_badhit;
        }
    }
}
