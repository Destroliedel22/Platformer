using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] List<Transform> fruitSpawns = new List<Transform>();
    [SerializeField] GameObject ShakeCanvas;
    [SerializeField] 

    public GameObject Fruit;

    private Transform camera;
    private Transform fruitSpawn;
    private int maxFruitAmount;
    private bool shaken;

    private void Awake()
    {
        camera = FindObjectOfType<Camera>().transform;
    }

    private void Update()
    {
        ShakeCanvas.transform.LookAt(camera);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && fruitSpawns.Count > 0)
        {
            ShakeCanvas.SetActive(true);
            if (InteractInput.Instance.click == 1)
            {
                if(shaken == false && maxFruitAmount < 3)
                {
                    Shake();
                    shaken = true;
                    StartCoroutine(WaitToShake());
                    maxFruitAmount++;
                }
            }
        }
        else if(fruitSpawns.Count == 0)
        {
            ShakeCanvas.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ShakeCanvas.SetActive(false);
        }
    }

    //drops an apple out the tree on a random spawn from the list
    public void Shake()
    {
        Transform randomTransform = fruitSpawns[Random.Range(0, fruitSpawns.Count)];
        fruitSpawn = randomTransform;
        Instantiate(Fruit, fruitSpawn.position, Quaternion.identity, fruitSpawn);
        fruitSpawns.Remove(fruitSpawn);
    }

    //waits till you can shake again
    IEnumerator WaitToShake()
    {
        yield return new WaitForSeconds(0.5f);
        shaken = false;
    }
}
