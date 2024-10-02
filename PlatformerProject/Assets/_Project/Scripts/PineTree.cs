using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PineTree : ShakableTrees, IShakables
{
    public void Shake()
    {
        Transform randomTransform = appleSpawns[Random.Range(0, appleSpawns.Count)];
        appleSpawn = randomTransform;
        Instantiate(PineApple, appleSpawn.position, Quaternion.identity, appleSpawn);
        appleSpawns.Remove(appleSpawn);
    }

    private void Update()
    {
        ShakeCanvas.transform.LookAt(camera);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && appleSpawns.Count > 0)
        {
            ShakeCanvas.SetActive(true);
            if (InteractInput.Instance.click == 1)
            {
                if(shaken == false)
                {
                    Shake();
                    shaken = true;
                    StartCoroutine(WaitToShake());
                }
            }
        }
        else if(appleSpawns.Count == 0)
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

    IEnumerator WaitToShake()
    {
        yield return new WaitForSeconds(0.5f);
        shaken = false;
    }
}
