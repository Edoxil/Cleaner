using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData/LevelData")]
public class LevelData : ScriptableObject
{
    public int number;
    public GameObject levelPrefab;
    public List<Dust> dustPrefabs => FindObjectsOfType<Dust>().ToList();


}
