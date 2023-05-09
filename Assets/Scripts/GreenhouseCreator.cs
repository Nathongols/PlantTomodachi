using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GreenhouseCreator : MonoBehaviour
{
    private void Start() {
        StartCoroutine(CreateInventory());
    }


    IEnumerator CreateInventory() {
        yield return new WaitForEndOfFrame();


    }
}
