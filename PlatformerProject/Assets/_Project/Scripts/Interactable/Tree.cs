using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour, IInteractable
{
    [SerializeField] List<Transform> fruitSpawns = new List<Transform>();
    [SerializeField] GameObject ShakeCanvas;
    [SerializeField] Image InteractButton;

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

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && fruitSpawns.Count > 0)
        {
            
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
            InTrigger();
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

    public void InTrigger()
    {
        if (InteractButton != null)
        {
            InteractButton.gameObject.SetActive(true);
        }
        else
        {
            ShakeCanvas.SetActive(true);
        }
    }

    //waits till you can shake again
    IEnumerator WaitToShake()
    {
        yield return new WaitForSeconds(0.5f);
        shaken = false;
    }
}
