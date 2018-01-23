using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooLateHitter : MonoBehaviour
{
    [SerializeField]
    ScoreHandler m_score;

    [SerializeField]
    NoteManager m_notemanager;

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Debug.Log("Too Late");
            m_score.TakeDamage();
            m_notemanager.RemoveNote();
        }
    }
}
