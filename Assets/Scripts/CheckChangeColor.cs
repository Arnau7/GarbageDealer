using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChangeColor : MonoBehaviour {

    Material m_Material;

    public Property property;

    public float capacity;
    public float capacityIncrease;
    public float maxCapacity;

    private float time = 0.0f;
    [SerializeField]
    float updateTime = 1;

    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        m_Material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (property == null)
            return;
        if(property.isPurchased)
            ChangeColor();

        time += Time.deltaTime;

        if (time > updateTime)
        {
            UpdateCapacity();
            time -= updateTime;
        }
    }

    public void ChangeColor()
    {
        if(capacity < maxCapacity / 3)
        {
            m_Material.color = Color.green;
        }else if(capacity < maxCapacity / 3 * 2)
        {
            m_Material.color = Color.yellow;
        }
        else if (capacity >= maxCapacity)
        {
            m_Material.color = Color.red;
        }
        else if (capacity > maxCapacity / 3 * 2)
        {
            m_Material.color = Color.gray;
        }
    }

    public void UpdateCapacity()
    {
        if(capacity <= maxCapacity-property.propertyIncomeIncrease)
            capacity += property.propertyIncomeIncrease;
    }
}
