using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerControl Player;
    public int Hp;
    public float[] cd;

    void Start()
    {
        Player = PlayerControl.cPlayer;
        StartCoroutine(getPlayerInit());
    }

    IEnumerator getPlayerInit() {
        yield return new WaitUntil(() => Player.status.canMove);
        Hp = Player.status.Hp;
        cd = new float[Player.status.skill.Count];
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cd.Length; i++)
        {
            cd[i] = Player.status.GetRemainCd(i);
        }
    }
}
