using UnityEngine;
using System.Collections;

public class Rubbish : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    protected GameObject floatingText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //Trigger floating text here
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
        }

        Destroy(gameObject);
        GameManager.Money += GameManager.RubbishMoney;
    }

    private void ShowFloatingText()
    {
        floatingText = Instantiate(FloatingTextPrefab, FindObjectOfType<Canvas>().transform);
        floatingText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 5, 0));
    }
}
