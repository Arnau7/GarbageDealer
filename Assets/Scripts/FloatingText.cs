using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 1f;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Text>().text = GameManager.RubbishMoney.ToString();
        Destroy(gameObject, destroyTime);
    }
}
