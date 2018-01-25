using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    [SerializeField]
    NoteManager m_notemanager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        m_notemanager.AddNote(collision.gameObject.GetComponent<Note>());
    }
}
