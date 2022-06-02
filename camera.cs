using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{ 
    public GameObject GGPlayer;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GGPlayer.transform.position.x, GGPlayer.transform.position.y, -450f);
    }
}
