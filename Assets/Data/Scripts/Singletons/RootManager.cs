using UnityEngine;

public class RootManager : SingletonParent<RootManager>
{
	[SerializeField] private bool isRetreating;
	[SerializeField] private Vector3 m_scaleAmount;
	[SerializeField] private float m_rootTimescale;
	[SerializeField] private Vector3 m_minimumScale;

	private float m_timer;

	private void Update()
	{
		m_timer += Time.deltaTime;
		
		Closing();
	}

	private void Closing()
	{
		float tempX = transform.localScale.x;
		
		if (isRetreating)
		{
			Retreating();
			return;
		}

		if (tempX <= m_minimumScale.x)
		{
			Debug.Log("Game Ended!");
			return;
		}

		if (m_timer < 1)
		{
			gameObject.transform.localScale += m_scaleAmount * m_rootTimescale;
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
			gameObject.transform.localScale -= m_scaleAmount * m_rootTimescale;
		}
		else
		{
			m_timer = 0;
			isRetreating = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Stop Do Damage To Player!");
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Do Damage To Player!");
		}
	}
}
