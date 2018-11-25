using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public Text textMoney, textMoneyPerSecond;
    // Use this for initialization
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    private void SetText()
    {
        textMoney.text = GameManager.Money.ToString();
        textMoneyPerSecond.text = "+" + GameManager.MoneyPerSecond.ToString() + "/sec"; ;
    }
}
