﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    // Dictionary = Lookup table
    private Dictionary<string, int> resource_count_map;

    public void Start()
    {
        resource_count_map = new Dictionary<string, int>();
    }

    public bool CanSpawn(Block block)
    {
        return resource_count_map.ContainsKey(block.resource_id);
    }

    public void OnResourcePickup(Resource resource)
    {
        string id = resource.resource_id;
        if (!resource_count_map.ContainsKey(id)) resource_count_map[id] = 0;

        resource_count_map[id]++;
    }

    public void OnBlockSpawn(Block block)
    {
        if (!CanSpawn(block))
        {
            Debug.Log("OnBlockSpawn called when unable to spawn block!");
            return;
        }

        resource_count_map[block.resource_id]--;
        if (resource_count_map[block.resource_id] == 0) resource_count_map.Remove(block.resource_id);
        LogResourceCountMap();
    }

    public void LogResourceCountMap()
    {
        foreach(KeyValuePair<string, int> entry in resource_count_map)
        {
            Debug.Log(entry.Key + " " + entry.Value);
        }
    }
}
