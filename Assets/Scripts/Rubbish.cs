using UnityEngine;
using System.Collections;
using Boo.Lang;
using UnityEngine.EventSystems;

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
        if(IsPointerOverUIObject()) return;
        //Trigger floating text here
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
        }

        transform.parent.gameObject.GetComponent<Spawn>().Occupied = false;
        Destroy(gameObject);
        GameManager.Money += GameManager.RubbishMoney;
    }

    private void ShowFloatingText()
    {
        floatingText = Instantiate(FloatingTextPrefab, FindObjectOfType<Canvas>().transform);
        floatingText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0));
    }
    
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
