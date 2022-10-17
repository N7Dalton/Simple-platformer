using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public Transform m_SpawnPoint;
    public GameObject m_PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        PlayerControllerpttwo.OnPlayerKilled += SpawnPlayer;
    }
    void SpawnPlayer()
    {
        Instantiate(m_PlayerPrefab, m_SpawnPoint.position, Quaternion.identity);
    }



}
