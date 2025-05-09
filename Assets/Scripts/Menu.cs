using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus = new List<GameObject>();
    [SerializeField] private int onMenu;

    void Awake()
    {
        onMenu = 0;
        
        menus[0].SetActive(true);

        for (int i = 1; i < menus.Count; i++)
        {
            menus[i].SetActive(false);
        }
    }

    void Update()
    {
        for (int i = 0; i < menus.Count; i++)
        {
            if (i != onMenu)
            {
                if (menus[i].active) menus[i].SetActive(false);
            }
            else if (!menus[onMenu].active) menus[onMenu].SetActive(true);
        }
    }

    public void ChangeMenu(int changeTo)
    {
        onMenu = changeTo;
    }
}
