using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : SingletonParent<RootManager>
{
	[SerializeField] private float m_rootPercentage;
	[SerializeField] private float m_rootTimescale;
	[SerializeField] private Sprite m_rootSprite;

	private void Update()
	{
		
	}

	private void OnValidate()
	{
		m_rootSprite = gameObject.GetComponent<Sprite>();
	}
}
