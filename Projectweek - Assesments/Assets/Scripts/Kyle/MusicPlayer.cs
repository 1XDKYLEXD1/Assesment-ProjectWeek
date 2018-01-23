using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	void Start ()
    {
        GetComponent<AudioSource>().Play();
	}
}
