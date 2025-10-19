using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPos = new Vector3(25, 0, 0);
    [SerializeField] private float startDelay;
    [SerializeField] private float repeatRate;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (PlayerController.instance.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
