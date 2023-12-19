using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRules();
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockManager.FM.allFish;

        Vector3 vCenter = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, transform.position);
                if (nDistance <= FlockManager.FM.neighbourDistance)
                {
                    vCenter += go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vAvoid = vAvoid + (transform.position - go.transform.position);
                    }

                    Flock anotherFlock = GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;

                }
            }
        }

        if (groupSize > 0)
        {
            vCenter = vCenter / groupSize;
            speed = gSpeed / groupSize;

            Vector3 direction = (vCenter + vAvoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      FlockManager.FM.rotSpeed * Time.deltaTime);
            }

        }

    }
}
