using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChangeColor : MonoBehaviour {

    Material m_Material;

    public static float Capacity;
    public static float MaxCapacity;

    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        m_Material = GetComponent<Renderer>().material;
       
    }

    private void Update()
    {
        if(Property.isPurchased)
            ChangeColor();
    }

    public void ChangeColor()
    {
        if(Capacity < MaxCapacity / 3)
        {
            m_Material.color = Color.green;
        }else if(Capacity < MaxCapacity / 3 * 2)
        {
            m_Material.color = Color.yellow;
        }
        else if (Capacity >= MaxCapacity)
        {
            m_Material.color = Color.red;
        }
        else if (Capacity > MaxCapacity / 3 * 2)
        {
            m_Material.color = Color.gray;
        }
    }
}
