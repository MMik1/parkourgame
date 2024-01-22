using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Spawnpoints : MonoBehaviour
{
 
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < - dead)
        {
            player.transform.position = vectorPoint;
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
        Destroy(other.gameObject);
    }
}