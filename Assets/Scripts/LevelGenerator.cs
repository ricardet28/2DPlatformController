using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    struct EntitySpawnData
    {
        [SerializeField] public Color pixelColor;
        [SerializeField] public GameObject prefabToSpawn;
    }

    public Texture2D colorMap;
    [SerializeField]List<EntitySpawnData> entitiesToSpawn = new List<EntitySpawnData>();

    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < colorMap.width; x++)
        {
            for (int y = 0; y < colorMap.height; y++)
            {
                GenerateEntity(x, y);
            }
        }
    }

    private void GenerateEntity(int x, int y)
    {
        Color pixelColor = colorMap.GetPixel(x, y);

        //Discard the transparent pixels
        if (pixelColor.a == 0)
            return; 

        for (int i = 0; i < entitiesToSpawn.Count; i++)
        {
            if (pixelColor.Equals(entitiesToSpawn[i].pixelColor))
            {
                Vector2 spawnPos = new Vector2(x, y);
                Instantiate(entitiesToSpawn[i].prefabToSpawn, spawnPos, Quaternion.identity, transform);
            }
        }
    }
}
