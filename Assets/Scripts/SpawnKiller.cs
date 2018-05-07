using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKiller : MonoBehaviour {

    public GameObject spectatorSpawn;

    private void Update()
    {
        if (GameObject.Find("SpawnA") && GameObject.Find("SpawnB") == null)
        {
            spectatorSpawn.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject); 
        }
    }
}
