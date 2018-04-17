using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    [SerializeField]
    List<Note> m_notes;

    [SerializeField]
    List<Note> m_allnotes;

    bool m_hittedendnote;

    public void RemoveNote()
    {
        if(m_allnotes[0].name == "EndNote")
        {
            Destroy(m_allnotes[0].gameObject);
            m_allnotes.Remove(m_allnotes[0]);
            m_hittedendnote = true;
        }
        else if(m_allnotes.Count != 0)
        {
            Destroy(m_allnotes[0].gameObject);
            m_allnotes.Remove(m_allnotes[0]);
        }
    }

    public void GameOver()
    {
        foreach(Note note in m_allnotes)
        {
            note.Stop();
        }
    }

    public void AddNote(Note note)
    {
        m_notes.Add(note);
    }

    public bool HittedEndNote()
    {
        return m_hittedendnote;
    }
}
