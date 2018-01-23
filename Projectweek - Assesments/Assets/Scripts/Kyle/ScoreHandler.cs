using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    int m_score;
    int m_failcount;
    bool m_dead;
    Text m_text;

    [SerializeField]
    PerfectHitter m_perfecthit;

    [SerializeField]
    GreatHitter m_greathit;

    [SerializeField]
    BadHitter m_badhit;

    [SerializeField]
    List<Image> m_lifes;

    [SerializeField]
    NoteManager m_notemanager;

    void Start()
    {
        m_text = GetComponent<Text>();
        m_dead = false;
        m_score = 0;
	}
	
	void Update ()
    {
        m_text.text = "Score : " + m_score.ToString();

        if(m_dead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_perfecthit.HitIsPerfect() && m_greathit.HitIsGreat())
                {
                    m_notemanager.RemoveNote();
                    m_score += 20;
                }
                else if (m_greathit.HitIsGreat() == true && m_perfecthit.HitIsPerfect() == false)
                {
                    m_notemanager.RemoveNote();
                    m_score += 10;
                }
                else if (m_greathit.HitIsGreat() == false && m_perfecthit.HitIsPerfect() == false && m_badhit.NoteIsInBadArea())
                {
                    m_notemanager.RemoveNote();
                    TakeDamage();
                    Debug.Log("Fail");
                }
            }
        }
        else
        {
            m_text.text = "GameOver!";
            m_notemanager.GameOver();
        }

        if(m_failcount == 3)
        {
            m_dead = true;
        }
	}

    public void TakeDamage()
    {
        m_lifes[m_failcount].gameObject.SetActive(false);
        m_failcount += 1;
    }
}
