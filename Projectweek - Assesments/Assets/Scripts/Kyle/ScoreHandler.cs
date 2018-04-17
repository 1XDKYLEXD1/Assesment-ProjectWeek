using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ScoreStates
{
    Idle,
    TooLate,
    Missed,
    GoodHit,
    PerfectHit
};

public class ScoreHandler : MonoBehaviour
{
    int m_score;
    int m_failcount;
    bool m_dead;
    Text m_text;

    ScoreStates m_scorestate;

    [SerializeField]
    PerfectHitter m_perfecthit;

    [SerializeField]
    GreatHitter m_greathit;

    [SerializeField]
    BadHitter m_badhit;

    [SerializeField]
    TooLateHitter m_toolatehitter;

    [SerializeField]
    List<Image> m_lifes;

    [SerializeField]
    NoteManager m_notemanager;

    [SerializeField]
    Animator m_scoreanimatior;

    [SerializeField]
    FencingController m_fencingcntrl;

    [SerializeField]
    MusicPlayer m_musicplayer;

    bool m_playonce;
    bool m_victory;

    void Start()
    {
        m_scorestate = ScoreStates.Idle;
        m_text = GetComponent<Text>();
        m_dead = false;
        m_score = 0;
	}
	
	void Update ()
    {
        //m_scoreanimatior.SetInteger("State", (int)m_scorestate);

        if(m_victory == false)
        {
            m_text.text = "Score : " + m_score.ToString();
        }

        if (m_dead == true)
        {
            m_text.text = "GameOver!\nPress R To Restart";

            m_notemanager.GameOver();
            m_musicplayer.StopAudio();

            if (m_playonce == false)
            {
                m_fencingcntrl.PlayPlayerDeath();
                
                m_playonce = true;
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GamePlayTesting");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_dead == false)
            {
                if (m_perfecthit.HitIsPerfect() && m_greathit.HitIsGreat())
                {
                    m_scoreanimatior.Play("PerfectHit");
                    m_fencingcntrl.PlayRandomBlock();
                    m_notemanager.RemoveNote();
                    m_score += 20;
                }
                else if (m_greathit.HitIsGreat() == true && m_perfecthit.HitIsPerfect() == false)
                {
                    m_scoreanimatior.Play("GoodHit");
                    m_fencingcntrl.PlayRandomBlock();
                    m_notemanager.RemoveNote();
                    m_score += 10;
                }
                else if (m_greathit.HitIsGreat() == false && m_perfecthit.HitIsPerfect() == false && m_badhit.NoteIsInBadArea())
                {
                    m_scoreanimatior.Play("Missed");
                    m_fencingcntrl.PlayRandomPlayerHitted();
                    m_notemanager.RemoveNote();
                    TakeDamage();
                    Debug.Log("Fail");
                }

                if (m_notemanager.HittedEndNote() && m_dead == false)
                {
                    //Gewonnen
                    m_victory = true;
                    m_text.text = "YOU WIN!!";
                    m_musicplayer.StopAudio();
                    m_fencingcntrl.PlayEnemyDeath();
                }
            }
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

    public void SetState(ScoreStates state)
    {
        m_scorestate = state;
    }

    public void PlayTooLate()
    {
        m_scoreanimatior.Play("TooLate");
        m_fencingcntrl.PlayRandomPlayerHitted();
    }
}
