using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject panelAjuda;
    public GameObject panelRanking;

	public void Ajuda(bool open)
    {
        if (open)
        {
            panelAjuda.SetActive(true);
        }
        else
        {
            panelAjuda.SetActive(false);
        }
    }

    public void Ranking(bool open)
    {
        if (open)
        {
            panelRanking.SetActive(true);
        }
        else
        {
            panelRanking.SetActive(false);
        }
    }
}
