using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DebrisSpawner : MonoBehaviour
{
    public GameObject obstacle;

   

    // Start is called before the first frame update
    void Awake()
    {
        
        generateObstacle();
    }
    public void GenerateNextObstGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateObstacle", randomWait);
    }
    void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(obstacle, transform.position, transform.rotation);

        ObstacleIns.GetComponent<Debris>()._spawner = this;
    }
   

}