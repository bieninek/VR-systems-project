using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
	public Light myLight;
	public float minWaitTime;
	public float maxWaitTime;
	public float minLightIntensivity;
	public float maxLightIntensivity;
	
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
			myLight.intensity = Random.Range(minLightIntensivity, maxLightIntensivity);
		}
	}
}
