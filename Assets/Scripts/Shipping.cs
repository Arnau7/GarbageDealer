using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipping : MonoBehaviour
{

	public float maxCapacity;

	public float currentCapacity;

	private Animator anim;

	public bool onSea;
	
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCapacity >= maxCapacity)
		{
			currentCapacity = maxCapacity;
		}
		else if (currentCapacity >= maxCapacity * 0.75f)
		{
			onSea = true;
			anim.Play("Ship",0,0f);
			currentCapacity = 0;
		}
	}

	public void hasReturned()
	{
		onSea = false;
		
	}

	public void Pollute()
	{
		GameManager.SeaPollution += 5;
	}
}
