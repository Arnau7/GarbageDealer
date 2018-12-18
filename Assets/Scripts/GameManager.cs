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
    public Text pollutionText;

    public GameObject PanelUpgrades, gameOverPanel;

    public static int Pollution = 0;

    // Use this for initialization
    void Start()
    {
        Money = 0;
        MoneyPerSecond = 0;
        RubbishMoney = 10;
        rubbishLevel = 1;

        rubbishUpCost1 = 100;
        rubbishUpCost2 = 250;
        rubbishUpCost3 = 500;
        currentRubbishUpCost = rubbishUpCost1;
        nextRubbishMoney = 30;

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
            time -= updateTime;
        }

        if (Pollution >= 100)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
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

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Chetos()
    {
        Money = 10000;
        MoneyPerSecond = 10;
    }
}
