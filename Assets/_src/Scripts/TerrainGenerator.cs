using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainType> startTerrainTypes;
    [SerializeField] private List<TerrainType> standardTerrainTypes;
    [SerializeField] private int extraTerrainToSpawn;

    private List<GameObject> spawnedTerrains = new List<GameObject>();
    private float currentZPosition = 0;

    private void Start()
    {
        SpawnStartTerrain();
    }

    private void SpawnStartTerrain()
    {
        SpawnTerrain(startTerrainTypes);

        for (int i = 0; i < extraTerrainToSpawn; i++)
        {
            SpawnTerrain(standardTerrainTypes);
        }
    }

    private void SpawnTerrain(List<TerrainType> terrainTypes)
    {
        var terrain = GetRandomTerrainPrefab(terrainTypes);

        var spawnPosition = transform.position + new Vector3(0, 0, 5 * currentZPosition);
        var tempObject = Instantiate(terrain, spawnPosition, Quaternion.identity, transform);
        currentZPosition++;
    }

    private GameObject GetRandomTerrainPrefab(List<TerrainType> terrainTypes)
    {
        var randomTerrain = terrainTypes[Random.Range(0, terrainTypes.Count)];
        var randomPrefab = randomTerrain.PossibleTerrainPrefabs[Random.Range(0, randomTerrain.PossibleTerrainPrefabs.Count)];
        return randomPrefab;
    }
}
