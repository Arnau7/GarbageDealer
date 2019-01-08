using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawnManager : MonoBehaviour
{

	public GameObject[] Spawns;
	public GameObject GarbagePrefab;
	public float Cool;
	private void Update()
	{
		if (Cool > 0)
		{
			Cool -= Time.deltaTime;
		}
		else
		{
			GarbageSpawn();
		}
	}

	private void GarbageSpawn()
	{
		var i = Random.Range(0, Spawns.Length);
		var count = 0;
		while (Spawns[i].GetComponent<Spawn>().Occupied)
		{
			if (count < Spawns.Length)
			{
				i = Random.Range(0, Spawns.Length);
				count++;
			}
			else
			{
				return;
			}
		}
	
		Instantiate(GarbagePrefab, Spawns[i].transform);
		Spawns[i].GetComponent<Spawn>().Occupied = true;
		Cool = 5;
		
	}
}

