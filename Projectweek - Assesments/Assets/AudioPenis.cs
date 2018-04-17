using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPenis : MonoBehaviour
{
    AudioSource m_source;

    private void Start()
    {
        DontDestroyOnLoad(this);
        m_source = GetComponent<AudioSource>();
    }

    public void StopAudio()
    {
        m_source.Stop();
    }
}
