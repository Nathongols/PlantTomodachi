using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance; 
    
    public Plant[] plants;
    public Plant[] activePlants;

    private float timer;
    private void Awake() {
        Instance = this;

        plants = Utils.GetAllInstances<Plant>();
    }

    private void Update() {
    }

    private void FixedUpdate() {
        timer += Time.deltaTime;
        if (timer > 5f) {
            IncrementPlantGrowth();
            timer = 0f;
        }

    }

    public void IncrementPlantGrowth(){
        foreach(Plant plant in plants) {
            if (plant.growthBool) {
                plant.growthTime += 0.1f;
                if (plant.growthTime >= 100f) {
                    plant.growthTime = 100f;
                    plant.growthBool = false;
                }
            }
        }
    }

    public float GetPercentGrowth(Plant plant){
        return (100f-plant.growthTime)/100f;
    }
}
