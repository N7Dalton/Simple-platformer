using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPoint;   
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = RespawnPoint.transform.position;
    }
}
