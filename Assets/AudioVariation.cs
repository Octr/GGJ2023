using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVariation : MonoBehaviour
{

    public AudioSource shooting;


    public void Awake()
    {
        shooting.pitch = Random.Range(0.7f,1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
