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
        IncrementPlantGrowth();
    }

    public void IncrementPlantGrowth(){
        foreach(Plant plant in plants) {
            if (plant.growthBool == true){
                plant.growthTime -= 0.01f;
            }
        }
    }

    public float GetPercentGrowth(Plant plant){
        return (100f-plant.growthTime)/100f;
    }
}
