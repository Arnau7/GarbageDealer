using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Property : MonoBehaviour
{
    public bool isPurchased;  //false (not purchased), true (purchased)
    public int propertyLevel; //0 not purchased, 1 purchased, 2 upgrade....
    public int propertyCost;  //changes according to the property level
    public int propertyIncome;
    public int propertyCapacity;
    public int propertyMaxCapacity;

    public Material m_Material;
    public CheckChangeColor buildingColor;

    private int propertyCostPurchase = 70;
    private int propertyCostLevel2 = 110;
    private int propertyCostLevel3 = 160;
    private int propertyCostLevel4 = 230;

    private int propertyIncomeLevel1 = 6;
    private int propertyIncomeLevel2 = 15;
    private int propertyIncomeLevel3 = 26;
    private int propertyIncomeLevel4 = 40;
    public int propertyIncomeIncrease = 0; //Variable summed to GameManager MoneyPerSecond

    private int propertyMaxCapacityLevel1 = 500;
    private int propertyMaxCapacityLevel2 = 750;
    private int propertyMaxCapacityLevel3 = 1000;
    private int propertyMaxCapacityLevel4 = 2000;
    private int propertyCurrentCapacity = 0; 

    private int maxLevel = 4;
    //Texts and strings for the Porperty Menu
    public Text textName, textIncome, textCapacity, textNextIncome, textNextCapacity, textCost;

    private string sPropertyNameLevel0 = "Building (Not owned)";
    private string sPropertyNameLevel1 = "Building Level 1";
    private string sPropertyNameLevel2 = "Building Level 2";
    private string sPropertyNameLevel3 = "Building Level 3";
    private string sPropertyNameLevel4 = "Building Level 4";

    private string sPropertyPurchaseCost = "70";
    private string sPropertyLevel2Cost = "110";
    private string sPropertyLevel3Cost = "160";
    private string sPropertyLevel4Cost = "230 ";

    private string sTextIncomeLevel1 = "6$/s";
    private string sTextIncomeLevel2 = "15$/s";
    private string sTextIncomeLevel3 = "26$/s";
    private string sTextIncomeLevel4 = "40$/s";

    private string sTextCapacityLevel1 = "500";
    private string sTextCapacityLevel2 = "750";
    private string sTextCapacityLevel3 = "1000";
    private string sTextCapacityLevel4 = "2000";

    public GameObject layoutCapacity, layoutIncome, layoutNextCapacity, layoutNextIncome;

    // Use this for initialization
    void Start()
    {
        //m_Material = GetComponent<Renderer>().material;

        isPurchased = false;
        propertyCost = propertyCostPurchase;
        propertyLevel = 0;

        SetPropertyTexts();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCapacityText();
    }

    //In charge of displaying all the property's texts information correctly and changing the values
    private void SetPropertyTexts()
    {
        if(propertyLevel == 0)
        {
            //Values
            propertyIncome = 0;

            //Texts
            textName.text = sPropertyNameLevel0;

            layoutIncome.SetActive(false);
            layoutCapacity.SetActive(false);
            textIncome.text = "";
            textCapacity.text = "";

            textNextIncome.text = sTextIncomeLevel1;
            textNextCapacity.text = sTextCapacityLevel1;

            textCost.text = sPropertyPurchaseCost;
        }
        else if(propertyLevel == 1)
        {
            //Values
            isPurchased = true; //CheckChangeColor now begins
            propertyCost = propertyCostLevel2;
            propertyIncome = propertyIncomeLevel1;
            propertyIncomeIncrease = propertyIncome;
            propertyMaxCapacity = propertyMaxCapacityLevel1;

            //Texts
            textName.text = sPropertyNameLevel1;

            layoutIncome.SetActive(true);
            layoutCapacity.SetActive(true);
            textIncome.text = sTextIncomeLevel1;
            textCapacity.text = sTextCapacityLevel1;

            textNextIncome.text = sTextIncomeLevel2;
            textNextCapacity.text = sTextCapacityLevel2;

            textCost.text = sPropertyLevel2Cost;
        }
        else if (propertyLevel == 2)
        {
            //Values
            propertyCost = propertyCostLevel3;
            propertyIncome = propertyIncomeLevel2;
            propertyIncomeIncrease = propertyIncomeLevel2-propertyIncomeLevel1;
            propertyMaxCapacity = propertyMaxCapacityLevel2;

            //Texts
            textName.text = sPropertyNameLevel2;

            textIncome.text = sTextIncomeLevel2;
            textCapacity.text = sTextCapacityLevel2;

            textNextIncome.text = sTextIncomeLevel3;
            textNextCapacity.text = sTextCapacityLevel3;

            propertyCost = propertyCostLevel3;
            textCost.text = sPropertyLevel3Cost;
        }
        else if (propertyLevel == 3)
        {
            //Values
            propertyCost = propertyCostLevel4;
            propertyIncome = propertyIncomeLevel3;
            propertyIncomeIncrease = propertyIncomeLevel3 - propertyIncomeLevel2;
            propertyMaxCapacity = propertyMaxCapacityLevel3;

            //Texts
            textName.text = sPropertyNameLevel3;

            textIncome.text = sTextIncomeLevel3;
            textCapacity.text = sTextCapacityLevel3;

            textNextIncome.text = sTextIncomeLevel4;
            textNextCapacity.text = sTextCapacityLevel4;
            
            textCost.text = sPropertyLevel4Cost;
        }
        else if (propertyLevel == 4)
        {
            //Values
            propertyIncome = propertyIncomeLevel4;
            propertyIncomeIncrease = propertyIncomeLevel4 - propertyIncomeLevel3;
            propertyMaxCapacity = propertyMaxCapacityLevel4;

            //Texts
            textName.text = sPropertyNameLevel4;

            textIncome.text = sTextIncomeLevel4;
            textCapacity.text = sTextCapacityLevel4;

            layoutNextIncome.SetActive(false);
            layoutNextCapacity.SetActive(false);
            textNextIncome.text = "";
            textNextCapacity.text = "";

            textCost.text = "MAX";
        }

        buildingColor.maxCapacity = propertyMaxCapacity;
        GameManager.MoneyPerSecond += propertyIncomeIncrease;
    }

    //Function for the property's Purchase/Upgrade button. Checks if the player has enough money and acts consequently
    public void PropertyUpgrade()
    {
        if (propertyLevel < maxLevel)
        {
            if (GameManager.Money >= propertyCost)
            {
                GameManager.Money -= propertyCost;
                propertyLevel++;
                SetPropertyTexts();
            }
            else
            {
                //Cannot purchase feedback
            }
        }
        else
        {
            //Property is at MAX Level
        }
    }
    
    private void UpdateCapacityText()
    {
        textCapacity.text = buildingColor.capacity.ToString() + "/" + propertyMaxCapacity;
    }
}
