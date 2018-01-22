using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D m_rigibody;

    [SerializeField]
    float m_speed;
    
	void Start ()
    {
        m_rigibody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        //m_rigibody.velocity = new Vector2(Mathf.Clamp(m_rigibody.velocity.x, 0, -0.4f), 0);

        m_rigibody.velocity += new Vector2(m_speed, 0);

        if (m_rigibody.velocity.x < m_speed)
        {
            m_rigibody.velocity = new Vector2(m_speed, 0);
        }
	}
}
