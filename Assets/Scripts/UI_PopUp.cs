using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PopUp : MonoBehaviour
{

    public GameObject PopUpPrefab;
    protected GameObject PopUpMessage;

    [SerializeField]
    private bool isClicked;


    void Start()
    {
        isClicked = false;
        
    }

    void Update()
    {
        if (isClicked)
        {
            CheckCameraPosition();
            CheckClickOutisde();
        }
    }

    //Input
    private void OnMouseUp()
    {
        isClicked = true;
        if (!PopUpMessage)
        {
            PopUpMessage = Instantiate(PopUpPrefab, FindObjectOfType<Canvas>().transform);
            PopUpMessage.transform.SetAsFirstSibling();
            PopUpMessage.GetComponent<Property>().buildingColor = GetComponent<CheckChangeColor>();
            GetComponent<CheckChangeColor>().property = PopUpMessage.GetComponent<Property>();
        }
        
        PopUpMessage.SetActive(true);
    }

    private void CheckCameraPosition()
    {
        PopUpMessage.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 4.5f, 0));
    }

    private void CheckClickOutisde()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100)) // or whatever range, if applicable
            {
                if (hit.transform.gameObject != gameObject)
                {
                    isClicked = false;
                    PopUpMessage.SetActive(false);
                    Debug.Log("Click outside");
                }

            }
            else
            {
                Debug.Log("Out of Ray");
            }
        }
    }
}
