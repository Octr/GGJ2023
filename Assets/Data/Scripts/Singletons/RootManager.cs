using UnityEngine;

public class RootManager : SingletonParent<RootManager>
{
	[SerializeField] private bool isRetreating;
	[SerializeField] private Vector3 m_scaleAmount;
	[SerializeField] private float m_rootTimescale;
	[SerializeField] private Vector3 m_minimumScale;

	private float m_timer;

	private bool m_playerIsInTheRoots;
	[SerializeField] private float m_damageToPlayer;
	private float m_damageTimer;
	[SerializeField] float m_damageTime;

	public GameObject hitmarker;

	private void Update()
	{
		m_timer += Time.deltaTime;
		
		Closing();

		if (m_playerIsInTheRoots)
        {
			m_damageTimer += Time.deltaTime;
			if (m_damageTimer >= m_damageTime)
			{
				if (PlayerMovementScript.instance.gameObject.activeInHierarchy)
                {
					PlayerMovementScript.instance.TakeDamage(m_damageToPlayer);
					GameObject newHitmarker = Instantiate(hitmarker);
					newHitmarker.transform.position = PlayerMovementScript.instance.transform.position;
					m_damageTimer = 0;
				}
				
			}

		}
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
			m_playerIsInTheRoots = false;
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Do Damage To Player!");
			m_playerIsInTheRoots = true;
		}
	}
}
