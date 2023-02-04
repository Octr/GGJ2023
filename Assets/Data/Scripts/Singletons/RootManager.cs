using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : SingletonParent<RootManager>
{
	[SerializeField] private bool isRetreating;
	[SerializeField] private Vector3 m_scaleAmount;
	[SerializeField] private float m_rootTimescale;
	[SerializeField] private SpriteRenderer m_spriteRenderer;

	private float m_timer;

	private void Update()
	{
		m_timer += Time.deltaTime;
		
		Closing();
	}

	private void Closing()
	{
		if (isRetreating)
		{
			Retreating();
			return;
		}

		if (m_timer < 1)
		{
			gameObject.transform.localScale += m_scaleAmount;
		}
		else
		{
			m_timer = 0;
		}
	}

	private void Retreating()
	{
		if (!isRetreating) return;
		if (m_timer < 1)
		{
			gameObject.transform.localScale -= m_scaleAmount;
		}
		else
		{
			m_timer = 0;
			isRetreating = false;
		}
	}

	private void OnValidate()
	{
		m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
}
