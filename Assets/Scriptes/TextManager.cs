
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    [SerializeField]
    private GameObject nom, text;

    private TextMeshProUGUI n, t;

    private bool isActive = false;

    private int index;

    private List<string> list;

    private void Awake()
    {
        n = nom.GetComponent<TextMeshProUGUI>();
        t = text.GetComponent<TextMeshProUGUI>();

        nom.SetActive(false);
        text.SetActive(false);
    }

    private void Update()
    {
        if(isActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(index < list.Count) 
                {
                    t.text = list[index];
                    index++;
                }
                else
                {
                    desactivation();
                }
                
            }
        }
    }


    public void activation(string name, List<string> list)
    {
        isActive = true;

        nom.SetActive(true);
        text.SetActive(true);

        this.list = list;

        n.text = name;
        t.text = this.list[0];
        index = 1;
    }

    public void desactivation()
    {
        n.text = "";
        t.text = "";

        nom.SetActive(false);
        text.SetActive(false);

        index = 0;

        StartCoroutine(CD());
    }

    IEnumerator CD()
    {
        yield return new WaitForSeconds(.1f);
        isActive = false;
    }

    public bool getIsActive() { return isActive; }
}
