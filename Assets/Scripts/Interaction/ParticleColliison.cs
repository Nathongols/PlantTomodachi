using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColliison : MonoBehaviour
{
    private PlantClass plant;
    private GameObject plantObject;
    private void OnParticleCollision(GameObject other) {
        Debug.Log("Particle Collision");
        plant = other.GetComponent<PlantClass>();
        plant.WaterPlant();
    }
}
