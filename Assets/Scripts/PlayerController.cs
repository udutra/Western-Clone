using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int keyIndex = 8;
    public int playerIndex;
    private bool canPlay = false;
    private float timer;
    private float nextKeyTime;
    public Animator anim;
    public bool npc = false;

    private IEnumerator Start()
    {
        while (LevelController.instance.canPlay == false)
        {
            yield return null;
        }

        canPlay = true;
    }

    private void Update () {
        if(canPlay == false)
        {
            return;
        }

        timer += Time.deltaTime;

        if (npc)
        {
            if(Time.time > nextKeyTime)
            {
                nextKeyTime = Time.time + Random.Range(0.25f, 0.5f);
                KeyPress();
            }
            return;
        }

        if (Input.GetButtonDown(LevelController.instance.gameKeys[keyIndex].key[playerIndex]))
        {
            KeyPress();
        }
        else if(Input.anyKeyDown){
            timer += 0.2f;
        }
	}

    private void KeyPress()
    {
        LevelController.instance.NextKey(playerIndex, keyIndex);
        keyIndex--;
        if(keyIndex < 0)
        {
            canPlay = false;
            LevelController.instance.UpdatePlayerTime(timer, playerIndex);
        }
    }

    public void SetAnimation(string triggerAnimation)
    {
        anim.SetTrigger(triggerAnimation);
    }
}
