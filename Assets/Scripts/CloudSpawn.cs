using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public float minY, maxY;
    public float minTime, maxTime;
    public GameObject[] cloud;
    public float offset;
    public float minSpeed, maxSpeed;
    public Transform cloudBound;
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        SpawnCloud();
    }

    public void SpawnCloud()
    {
        GameObject e = Instantiate(cloud[Random.Range(0, cloud.Length)]) as GameObject;
        e.transform.position = new Vector3(transform.position.x + offset, Random.Range(minY, maxY), 0);
        e.GetComponent<SkyObject>().vel = Random.Range(minSpeed, maxSpeed);
        e.GetComponent<SkyObject>().travelRight = false;
        e.GetComponent<SkyObject>().boundary = cloudBound;
        StartCoroutine(SpawnDelay());
    }
}
