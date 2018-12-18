using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour {

    public static float Capacity = 0;
    public static float MaxCapacity = 10000;

    public Material m_Material;
    public ChangeFarmColor farmColor;
    private bool isIncinerating = false;
    public Text textName, textCapacity, incinerateText;

    private float time = 0.0f;
    float updateTime = 1;

    // Use this for initialization
    void Start () {
        Capacity = 0;
        MaxCapacity = 10000;
        textName.text = "Farm Camps";

        //SetTexts();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTexts();

        time += Time.deltaTime;

        if (isIncinerating)
        {
            if(Capacity > 0)
            {
                if (time > updateTime)
                {
                    Capacity -= 100;
                    if(Capacity < 0)
                    {
                        Capacity = 0;
                    }
                    GameManager.Pollution += 1;
                    time -= updateTime;
                }
            }
        }
	}

    private void UpdateTexts()
    {
        textCapacity.text = Capacity.ToString() + "/" + MaxCapacity.ToString();
    }
    private void SetTexts()
    {
        //farmColor.maxCapacity = MaxCapacity;
    }

    public void Incinerate()
    {
        if (!isIncinerating)
        {
            isIncinerating = true;
            incinerateText.text = "Stop Incinerate";
        }
        else if (isIncinerating)
        {
            isIncinerating = false;
            incinerateText.text = "Incinerate";
        }

    }

}
