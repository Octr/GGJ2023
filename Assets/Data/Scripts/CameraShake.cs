using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public static CameraShake instance;
	
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.3f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		CameraShake.instance = this;
		
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	public void CameraShakeByTime(float shaketime)
	{
		shakeDuration = shaketime;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}

	/*
	private void OnGUI()
	{
		
		if(GUILayout.Button("Test shake"))
		{
			CameraShakeByTime(0.1f);
		}
	}
	
	*/
}