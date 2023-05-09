using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColliison : MonoBehaviour
{
    private PlantClass plant;
    private void OnParticleCollision(GameObject other) {
            plant = other.GetComponent<PlantClass>();
            plant.WaterPlant();
    }
}
