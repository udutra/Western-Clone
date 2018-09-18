using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int keyIndex = 8;
    public int playerIndex;
    private bool canPlay = false;

    private IEnumerator Start()
    {
        while (LevelController.instance.canPlay == false)
        {
            yield return null;
        }

        canPlay = true;
    }

    void Update () {
        if(canPlay == false)
        {
            return;
        }

        if (Input.GetKeyDown(LevelController.instance.gameKeys[keyIndex].key))
        {
            KeyPress();
        }
	}

    private void KeyPress()
    {
        LevelController.instance.NextKey(playerIndex, keyIndex);
        keyIndex--;
        if(keyIndex < 0)
        {
            canPlay = false;
        }
    }
}
