using UnityEngine;

public abstract class SingletonParent<T> : MonoBehaviour where T : SingletonParent<T>
{
	public static T Instance
	{
		get;
		private set;
	}

	protected virtual void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = (T)this;
	}

	protected virtual void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}