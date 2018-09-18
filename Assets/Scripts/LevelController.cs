using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public Keys[] keys;
    public List<Keys> gameKeys;
    public Image[] player1Images;
    public Image[] player2Images;
    public static LevelController instance;
    public bool canPlay = false;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        StartCoroutine(StartingKeys());
	}

	void Update () {
		
	}

    IEnumerator StartingKeys()
    {
        for (int i = 0; i < player1Images.Length; i++)
        {
            gameKeys.Add(keys[UnityEngine.Random.Range(0, keys.Length)]);
            player1Images[i].sprite = gameKeys[i].keySprite;
            player1Images[i].preserveAspect = true;
            player1Images[i].enabled = true;
            player2Images[i].sprite = gameKeys[i].keySprite;
            player2Images[i].preserveAspect = true;
            player2Images[i].enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
        canPlay = true;
    }

    public void NextKey(int playerIndex, int keyIndex)
    {
        if(playerIndex == 0)
        {
            player1Images[keyIndex].enabled = false;
        }
        else
        {
            player2Images[keyIndex].enabled = false;
        }
    }
}

[Serializable]
public class Keys
{
    public Sprite keySprite;
    public KeyCode key;
}
