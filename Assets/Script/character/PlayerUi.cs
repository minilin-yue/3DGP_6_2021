using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerUi currentUi;
    public PlayerControl Player;
    public int Hp;

    [SerializeField]
    private Animator HitAni;

    [Header("血量物件，在prefab中設定好")]
    public GameObject[] bloods;

    public Ui[] ui;
    void Start()
    {
        currentUi = this;
        Player = PlayerControl.cPlayer;
        StartCoroutine(getPlayerInit());
    }

    IEnumerator getPlayerInit() {
        yield return new WaitUntil(() => Player.status.canMove);
        Hp = Player.status.Hp;
        setFoodInfo();
        yield return null;
    }

    /// <summary>
    /// player被打的時候call這個
    /// </summary>
    public void HitEffect()
    {
        HitAni.Play("Hit",0,0);
        
    }

    public void DizEffect()
    {
        HitAni.Play("Diz", 0, 0);
    }


    /// <summary>
    /// 在改動技能列表的時候要call一次
    /// </summary>
    public void setFoodInfo() {
        FoodSkill[] temp = PlayerControl.cPlayer.GetFoodSkills();
        for (int i = 0; i < ui.Length; i++) {
            if(temp[i].Icon != null)
                ui[i].food.sprite = temp[i].Icon;
            ui[i].maxCd = temp[i].coolDownTime;
        }
        
    }

    void updateCd() {
        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].cd_layer.fillAmount = ui[i].cd / ui[i].maxCd;
        }
    }

    void UpdateHp() 
    {
        //UI玩家血量 (完成)
        for (int i = 0; i < 5; i++) {
            bloods[i].SetActive(i<Hp);
        }
    }

    void UpdateCount()
    {
        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].count.text = Player.status.skill[i].count.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < ui.Length; i++)
        {
            Hp = (int)Player.status.Hp;
            ui[i].cd = Player.status.GetRemainCd(i);
        }
        updateCd();
        UpdateHp();
        //UpdateCount();
    }
    private void LateUpdate()
    {
        //討論後再決定要用哪邊來控制UI顯示數量
        //UpdateCount();
    }
}
[System.Serializable]
public struct Ui
{
    public float cd;
    public float maxCd;
    public UnityEngine.UI.Image cd_layer;
    public UnityEngine.UI.Image food;
    public UnityEngine.UI.Text count;
};