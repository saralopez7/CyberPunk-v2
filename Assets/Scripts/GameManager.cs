using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public List<GameObject> ground;
    private int index;

    private bool running = true;

    private void Start()
    {
        ground = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ground"));
    }

    private IEnumerator CubeDestroyer()
    {
        running = false;

        index = Random.Range(0, ground.Count);

        ground[index].GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(2);

        Destroy(ground[index]);

        ground.RemoveAt(index);

        if (ground.Count > 0) StartCoroutine(CubeDestroyer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && running) StartCoroutine(CubeDestroyer());
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");
    }
}