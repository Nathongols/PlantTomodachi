using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantClass : MonoBehaviour
{
    public Plant plant;

    private const float nextActionTime = 5f;
    private float timer = 0f;
    void Start()
    {
    }

    void Update()
    {
        Debug.Log(plant.waterNeeded);
        timer += Time.deltaTime;

        if( timer > nextActionTime) {
            Debug.Log("Checking Growth Requirements");
            if (plant.waterNeeded > 100) {
                plant.growthBool = true;
            }
            timer = 0f;
        }
    }

    public void WaterPlant() {
        plant.waterNeeded += 1;
        Debug.Log("Watered");
    }
}
