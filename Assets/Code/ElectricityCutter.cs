using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityCutter : MonoBehaviour
{
    [SerializeField] GameObject lights;

    float waitTime = 0.2f;

    public void CutOfElectricity()
    {
        lights.SetActive(!lights.activeSelf);
        StartCoroutine("TinkerElectricity");   
    }

    IEnumerator TinkerElectricity() 
    {
        while (waitTime > 0.0f)
        {
            yield return new WaitForSeconds(waitTime);
            lights.SetActive(!lights.activeSelf);
            waitTime -= 0.01f;
            if (waitTime <= 0.0f) {
                AudioSource audioSouce = GetComponent<AudioSource>();
                audioSouce.Play();
            }
        }

    }
}
