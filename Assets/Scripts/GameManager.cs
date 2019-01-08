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
    private float time3 = 0.0f;
    [SerializeField]
    float updateTime = 1;
    float pollutionRestoreTime = 10;
    float seaPollutionRestoreTime = 13;

    public Text textUpgrade1Ttitle, textUpgrade1Level, textUpgrade1Current, textUpgrade1Next, textUpgrade1Cost;
    public Text pollutionText, seaPollutionText;
    public Text shipCostText;
    public Text moneyGameOver;

    public GameObject PanelUpgrades, gameOverPanel, infoPanel, aboutPanel;

    public static int Pollution = 0;
    public static int SeaPollution = 0;
    public static bool hasShip;

    public GameObject slot1, slot2, slot3, slot4, slot5, slot6;
    int messagesNum = 0;

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

        if (time3 > seaPollutionRestoreTime)
        {
            SeaPollution -= 1;
            if (SeaPollution < 0)
            {
                SeaPollution = 0;
            }
            time3 -= seaPollutionRestoreTime;
        }
    }
    private void GameOver()
    {
        moneyGameOver.text = Money.ToString();
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
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
        {
            if (infoPanel.activeInHierarchy || aboutPanel.activeInHierarchy)
            {
                infoPanel.SetActive(false);
                aboutPanel.SetActive(false);
            }
            PanelUpgrades.SetActive(true);
        }
    }
    
    public void InfoPanelFunc()
    {
        if (infoPanel.activeInHierarchy)
        {
            infoPanel.SetActive(false);
            InfoPanelMessages(); //Updates messages displayed in the Info Panel
        }
        else
        {
            if (PanelUpgrades.activeInHierarchy || aboutPanel.activeInHierarchy)
            {
                PanelUpgrades.SetActive(false);
                aboutPanel.SetActive(false);
            }
            infoPanel.SetActive(true);
        }
    }
    public void AboutPanelFunc()
    {
        if (aboutPanel.activeInHierarchy)
        {
            aboutPanel.SetActive(false);
        }
        else
        {
            if (PanelUpgrades.activeInHierarchy || infoPanel.activeInHierarchy)
            {
                PanelUpgrades.SetActive(false);
                infoPanel.SetActive(false);
            }
            aboutPanel.SetActive(true);
        }
    }
    public void InfoPanelMessages()
    {
        if(messagesNum == 0)
        {
            slot1.SetActive(true);
            slot2.SetActive(true);
            slot3.SetActive(true);
            slot4.SetActive(false);
            slot5.SetActive(false);
            slot6.SetActive(false);
            messagesNum = 1;
        }
        else if(messagesNum == 1)
        {
            slot1.SetActive(false);
            slot2.SetActive(false);
            slot3.SetActive(false);
            slot4.SetActive(true);
            slot5.SetActive(true);
            slot6.SetActive(true);
            messagesNum = 0;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
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
