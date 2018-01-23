using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    [SerializeField]
    List<Note> m_notes;

    public void RemoveNote()
    {
        if (m_notes.Count != 0)
        {
            //m_notes[0].gameObject.SetActive(false);
            Destroy(m_notes[0].gameObject);
            m_notes.Remove(m_notes[0]);
        }
    }

    public void GameOver()
    {
        foreach(Note note in m_notes)
        {
            note.Stop();
        }
    }

    public void AddNote(Note note)
    {
        m_notes.Add(note);
    }
}
