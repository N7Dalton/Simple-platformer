using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnpoint;
    public Transform player;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        player.transform.Translate(new Vector3(0, 100, 0));

    }

    private void Update()
    {
      
    }

}
