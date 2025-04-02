using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawn : MonoBehaviour
{
    public float minY, maxY;
    public float minTime, maxTime;
    public GameObject eagle;
    public float offset;
    public float minSpeed, maxSpeed;
    public Transform eagleBound;
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        SpawnEagle();
    }

    public void SpawnEagle()
    {
        GameObject e = Instantiate(eagle) as GameObject;
        e.transform.position = new Vector3(transform.position.x + offset, Random.Range(minY, maxY), 0);
        e.GetComponent<SkyObject>().vel = Random.Range(minSpeed, maxSpeed);
        e.GetComponent<SkyObject>().travelRight = true;
        e.GetComponent<SkyObject>().boundary = eagleBound;
        StartCoroutine(SpawnDelay());
    }
}
