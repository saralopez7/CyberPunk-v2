using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] components;
    Camera sceneCamera;
    float speed = 1000;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].enabled = false;
            }
        }
        else
        {
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(false);
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;

            this.GetComponent<Rigidbody>().AddForce(direction * speed);
        }
    }*/

  
}