using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantClass : MonoBehaviour
{
    public Plant plant;

    private const float nextActionTime = 5f;
    private float timer = 0f;

    public GameObject plantStage1;
    public GameObject plantStage2;
    public GameObject plantStage3;
    public GameObject plantStage4;
    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;

        if( timer > nextActionTime) {
            Debug.Log("Checking Growth Requirements");
            if (plant.waterNeeded < 10 && plant.growthTime < 100f) {
                plant.growthBool = true;
            }
            else {
                plant.growthBool = false;
            }
            if (plant.waterNeeded < 0){
                plant.waterNeeded = 0;
            }

            // Swap Plant Stages
            if (plant.growthTime >= 100f) {
                plantStage1.SetActive(false);
                plantStage2.SetActive(false);
                plantStage3.SetActive(false);
                plantStage4.SetActive(true);
            }
            else if (plant.growthTime >= 75f) {
                plantStage1.SetActive(false);
                plantStage2.SetActive(false);
                plantStage3.SetActive(true);
                plantStage4.SetActive(false);
            }
            else if (plant.growthTime >= 50f) {
                plantStage1.SetActive(false);
                plantStage2.SetActive(true);
                plantStage3.SetActive(false);
                plantStage4.SetActive(false);
            }
            else if (plant.growthTime >= 25f) {
                plantStage1.SetActive(true);
                plantStage2.SetActive(false);
                plantStage3.SetActive(false);
                plantStage4.SetActive(false);
            }
            else {
                plantStage1.SetActive(false);
                plantStage2.SetActive(false);
                plantStage3.SetActive(false);
                plantStage4.SetActive(false);
            }

            plant.waterNeeded += 1;
            timer = 0f;
        }
    }

    public void WaterPlant() {
        plant.waterNeeded -= 0.1f;
        Debug.Log("Watered");
    }
}
