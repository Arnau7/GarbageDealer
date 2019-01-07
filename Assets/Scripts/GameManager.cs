using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Money;
    public static int MoneyPerSecond;
    public static int PropertiesNum;
    
    public static int RubbishMoney;
    private int rubbishLevel;
    public int rubbishUpCost1, rubbishUpCost2, rubbishUpCost3, currentRubbishUpCost, nextRubbishMoney;

    private float time = 0.0f;
    private float time2 = 0.0f;
    [SerializeField]
    float updateTime = 1;
    float pollutionRestoreTime = 10;

    public Text textUpgrade1Ttitle, textUpgrade1Level, textUpgrade1Current, textUpgrade1Next, textUpgrade1Cost;
    public Text pollutionText, seaPollutionText;
    public Text shipCostText;

    public GameObject PanelUpgrades, gameOverPanel, infoPanel;

    public static int Pollution = 0;
    public static int SeaPollution = 0;
    public static bool hasShip;
   

    // Use this for initialization
    void Start()
    {
        Money = 5000;
        MoneyPerSecond = 0;
        RubbishMoney = 10;
        rubbishLevel = 1;
        //Pollution = 300;
        rubbishUpCost1 = 100;
        rubbishUpCost2 = 250;
        rubbishUpCost3 = 500;
        currentRubbishUpCost = rubbishUpCost1;
        nextRubbishMoney = 30;
        Pollution = 0;
        SeaPollution = 0;
        hasShip = false;
        SetUpgradeTexts();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

        if (time > updateTime)
        {
            MoneyIncome();
            pollutionText.text = Pollution.ToString() + "%";
            seaPollutionText.text = SeaPollution.ToString() + "%";
            time -= updateTime;
        }

        if (Pollution >= 100 || SeaPollution >= 100)
        {
            Pollution = 100;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            
        }

        if(time2 > pollutionRestoreTime)
        {
            Pollution -= 1;
            if(Pollution < 0)
            {
                Pollution = 0;
            }
            time2 -= pollutionRestoreTime;
        }


    }

    private void MoneyIncome()
    {
        Money += MoneyPerSecond;
    }

    private void SetRubbishMoney()
    {
        if(rubbishLevel == 1)
        {
            RubbishMoney = 10;
        }
        else if(rubbishLevel == 2)
        {
            RubbishMoney = 30;
            currentRubbishUpCost = rubbishUpCost2;
            nextRubbishMoney = 70;
        }
        else if(rubbishLevel == 3)
        {
            RubbishMoney = 70;
            currentRubbishUpCost = rubbishUpCost3;
            nextRubbishMoney = 210;
        }
        else if (rubbishLevel == 4)
        {
            RubbishMoney = 210;
            currentRubbishUpCost = 0;
            nextRubbishMoney = 0;
        }
    }
    private bool CanUpgradeRubbish()
    {
        if(Money >= currentRubbishUpCost)
        {
            if (rubbishLevel < 4)
            {
                Money -= currentRubbishUpCost;
                rubbishLevel++;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    private void SetUpgradeTexts()
    {
        textUpgrade1Level.text = "Level " + rubbishLevel.ToString();

        if (currentRubbishUpCost == 0)
            textUpgrade1Cost.text = "MAX";
        else
            textUpgrade1Cost.text = currentRubbishUpCost.ToString() + "$";

        textUpgrade1Current.text = RubbishMoney.ToString() + "$ / bag";

        if (nextRubbishMoney == 0)
            textUpgrade1Next.text = "";
        else
            textUpgrade1Next.text = nextRubbishMoney.ToString() + "$ / bag";

    }

    public void RubbishUpgradeButton()
    {
        if (CanUpgradeRubbish())
        {
            SetRubbishMoney();
            SetUpgradeTexts();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void InteractPanelUpgrades()
    {
        if (PanelUpgrades.activeInHierarchy)
            PanelUpgrades.SetActive(false);
        else
            PanelUpgrades.SetActive(true);
    }
    
    public void InfoPanelFunc()
    {
        if (infoPanel.activeInHierarchy)
            infoPanel.SetActive(false);
        else
            infoPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Chetos()
    {
        Money = 10000;
        MoneyPerSecond = 10;
    }

    public void BuyShip(GameObject ship)
    {
        if (Money < 2000) return;
        Money -= 2000;
        shipCostText.text = "Unlocked";
        ship.SetActive(true);
        hasShip = true;
    }
}
