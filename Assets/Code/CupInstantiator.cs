using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class CupInstantiator : MonoBehaviour
{
    [SerializeField] Object cupPrefab;
    [SerializeField] Transform celling;

    float waitTime = 1.2f;

    // location as Vector3
    float locX;
    float locY;
    float locZ;

    private void Awake()
    {
        locX = celling.localPosition.x;
        locY = celling.localPosition.y;
        locZ = celling.localPosition.z;

        // print an identity quaternion on Awake (hi Kris)
        #region
        //Debug.Log("x: " + Quaternion.identity.x);
        //Debug.Log("y: " + Quaternion.identity.y);
        //Debug.Log("z: " + Quaternion.identity.z);
        //Debug.Log("w: " + Quaternion.identity.w);
        #endregion

        // clear quaternion log
        File.Delete("QuaternionLog.txt");
    }

    private IEnumerator InstatiateCupsFromCelling() 
    {
        while (true)
        {
            Instantiate(cupPrefab, RandomizeSpawnPoint(), RandomizeUpRotation());
 
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void StartInstatiating() 
    {
        StartCoroutine("InstatiateCupsFromCelling");
    }

    private Vector3 RandomizeSpawnPoint() 
    {
        float tempX;
        float tempZ;

        tempX = locX + Random.Range(-2.0f, 2.0f);
        tempZ = locZ + Random.Range(-2.0f, 2.0f);

        return new Vector3(tempX, locY, tempZ);
    }

    private Quaternion RandomizeUpRotation()
    {
        float y;
        float w;

        y = Random.Range(-1.0f, 1.0f);
        w = Mathf.Sqrt(1.0f - Mathf.Pow(y, 2));

        // cache quaternion values to txt file
        File.AppendAllText("QuaternionLog.txt", $"{y,10:F5} {w,10:F5} {(Math.Pow(y,2) + Math.Pow(w,2)),10:F5}" + Environment.NewLine);

        return new Quaternion(0, y, 0, w);
    }
}
