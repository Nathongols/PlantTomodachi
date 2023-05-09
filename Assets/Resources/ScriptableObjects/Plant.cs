using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "ScriptableObjects/Plant", order = 0)]
public class Plant : ScriptableObject {
    public Sprite sprite;
    public string plantName;
    public int id; 
    public int price;
    public float growthTime;
    public float waterNeeded;
    public int fertilizerNeeded;
    public bool growthBool;
}