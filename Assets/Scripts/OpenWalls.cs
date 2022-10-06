using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWalls : MonoBehaviour
{
    public float Lwall;
    public float Rwall;
    public float speed = 0.001f;
    // Start is called before the first frame update
    IEnumerator Open()
    {
       yield return new WaitForSeconds(30);
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += transform.right * Time.deltaTime;
    }
}
