using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject fishPrefab;
    public int fishNum = 20;
    public GameObject[] allFish;
    public Vector3 swimLimits = new Vector3(5, 5, 5);

    [Header("Speed Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(1.0f, 5.0f)]
    public float rotSpeed;
    void Start()
    {
        allFish = new GameObject[fishNum];
        for (int i = 0; i < fishNum; i++)
        {


            Vector3 pos = transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x)
                                                         , Random.Range(-swimLimits.y, swimLimits.y)
                                                         , Random.Range(-swimLimits.z, swimLimits.z));

            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
        }
        FM = this;
    }


}
