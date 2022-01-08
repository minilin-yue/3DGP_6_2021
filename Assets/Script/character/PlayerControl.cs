using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    /// <summary>
    /// we can use this to access current plauer
    /// </summary>
    public static PlayerControl cPlayer;
    bool fire = false;

    private void Awake()
    {
        cPlayer = this;
        Debug.Log("current player name = " + this.gameObject.name);
    }

    public UnityEngine.CharacterController controller;
    /// <summary>
    /// all player current value
    /// </summary>
    //[HideInInspector]
    public PlayerStatus status;
    [SerializeField]
    KeySetting playerKey;
    public Camera playerCam;
    [SerializeField]
    Animator slingAni;
    [SerializeField]
    float shotAniLen = 1.5f;
    private Coroutine slingShotCoro;
    [SerializeField]
    private FoodSkill N_atk;
    //[Header("血量")]
    //public float blood = 5;
    [Header("敵人攻擊的Tag")]
    public string Enemy_Atk_tag = "enemy_weapon";
    private bool CanBeHit = true;

    [Header("HP歸零 的 暈眩時間")]
    public float DizTime = 3f;
    [Header("放入在各關卡可使用的技能設定")]
    public SceneFoodTable SceneFoodSetting;

    [Header("移動相關參數")]
    public float speed = 5;

    [Header("跳躍相關參數")]
    public float gravity = -9.18f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 3.0f;
    public LayerMask groundMask;

    [Header("技能是補血的話打勾")]
    public bool heal1 = false;
    public bool heal2 = false;
    public bool heal3 = false;
    public bool heal4 = false;

    private Voice voice;

    Vector3 velocity;
    bool isGrounded {
        get {
            Vector3 start = groundCheck.position;
            Vector3 end = new Vector3(start.x, start.y - groundDistance,start.z);
            if (Physics.Linecast(start, end, groundMask))
                return true;
            else
                return false; 
        }
    }

    /// <summary>
    /// contains move and jump
    /// </summary>
    private void Movement()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey("left shift") && isGrounded)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(playerKey.jump) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    #region skill
    //record cool down
    List<KeyCode> coolDonwKey = new List<KeyCode>();


    /// <summary>
    /// 切換關卡的改技能表時候要用這個
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeSkillSet(string sceneName)
    {
        switch (sceneName)
        {
            case "level1":
                playerKey.SkillKey = SceneFoodSetting.Skill_Scene1;
                status.init(status.Hp, playerKey.SkillKey);
                break;
            case "level2":
                playerKey.SkillKey = SceneFoodSetting.Skill_Scene2;
                status.init(status.Hp, playerKey.SkillKey);
                break;
            case "level3":
                playerKey.SkillKey = SceneFoodSetting.Skill_Scene3;
                status.init(status.Hp, playerKey.SkillKey);
                break;
            case "level4":
                playerKey.SkillKey = SceneFoodSetting.Skill_Scene4;
                status.init(status.Hp, playerKey.SkillKey);
                break;
            default:
                playerKey.SkillKey = SceneFoodSetting.Skill_Scene3;
                status.init(status.Hp, playerKey.SkillKey);
                break;
        }

    }


    private void SkillInput() {
        //foreach (FoodSkill skill in playerKey.SkillKey) {
        for (int i= 0;i < playerKey.SkillKey.Length;i++)
        {
            FoodSkill skill = playerKey.SkillKey[i];
            if (Input.GetKeyDown(skill.key) && !coolDonwKey.Contains(skill.key) && GM_level.Gm.GetFoodCount(i)>0) {
                //shoot
                GameObject pre = MonoBehaviour.Instantiate(skill.pref) as GameObject;
                pre.transform.position = playerCam.transform.position;
                pre.GetComponent<Rigidbody>().velocity = skill.InitSpeed * playerCam.transform.forward;
                pre.GetComponent<FoodInfo>().info = skill;
                voice.Play(1);
                //cool down
                StartCoroutine(coolDown(skill.key, skill.coolDownTime));
                StartCoroutine(status.CoolDownSkill(GetSkillIndex(skill), skill.coolDownTime));
                
                //sling shot animator
                if (slingShotCoro != null) { 
                    StopCoroutine(slingShotCoro);
                    slingAni.SetBool("shoot", false);
                    slingAni.Play("shot");
                }
                slingShotCoro = StartCoroutine(SlingShotAni());
                GM_level.Gm.ReduceFoodCount(i);
            }
        }
    }

    private IEnumerator NormalAtk() {
        yield return new WaitUntil(() => (Input.GetMouseButtonDown(0) && status.canMove));
        GameObject pre = MonoBehaviour.Instantiate(N_atk.pref) as GameObject;
        pre.transform.position = playerCam.transform.position;
        pre.GetComponent<Rigidbody>().velocity = N_atk.InitSpeed * playerCam.transform.forward;
        pre.GetComponent<FoodInfo>().info = N_atk;
        voice.Play(0);
        //sling shot animator
        if (slingShotCoro != null)
        {
            StopCoroutine(slingShotCoro);
            slingAni.SetBool("shoot", false);
            slingAni.Play("shot");
        }
        slingShotCoro = StartCoroutine(SlingShotAni());
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(NormalAtk());
    }

    private int GetSkillIndex(FoodSkill skill) { 
        for(int i = 0; i < playerKey.SkillKey.Length; i++)
        {
            if (skill == playerKey.SkillKey[i])
                return i;
        }
        return -1;
    }

    private IEnumerator coolDown(KeyCode coolKey,float time) {
        if (!coolDonwKey.Contains(coolKey))
            coolDonwKey.Add(coolKey);
        yield return new WaitForSeconds(time);
        coolDonwKey.Remove(coolKey);
        yield return null;
    }

    private IEnumerator SlingShotAni() {
        slingAni.SetBool("shoot", true);
        yield return new WaitForSeconds(shotAniLen);
        slingAni.SetBool("shoot", false);
        yield return null;
    }

    #endregion

    #region Ui
    public FoodSkill[] GetFoodSkills() {
        return playerKey.SkillKey;
    }


    #endregion

    #region Receive_damage
    /// <summary>
    /// 接觸到傷害後call這個
    /// </summary>
    public IEnumerator GiveDamage(Collider other)
    {
        CanBeHit = false;
        PlayerUi.currentUi.HitEffect();
        status.Hp = Mathf.Clamp(status.Hp - 1, 0, 5);
        voice.Play(2);
        yield return new WaitForSeconds(0.6f);
        CanBeHit = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Enemy_Atk_tag) && CanBeHit && status.canMove) {
            StartCoroutine(GiveDamage(other));
        }
        
    }

    #endregion

    #region Hp == Zero

    /// <summary>
    /// HP歸零時的暈眩處理
    /// </summary>
    /// <returns></returns>
    private IEnumerator Diz()
    {
        yield return new WaitUntil(() => status.Hp <= 0);
        PlayerUi.currentUi.DizEffect();
        status.canMove = false;
        yield return new WaitForSeconds(DizTime);
        status.canMove = true;
        status.Hp = 5;
        StartCoroutine(Diz());
        yield return null;

    }


    #endregion

    private void Start()
    {
        status.init(5, playerKey.SkillKey);
        ChangeSkillSet(SceneManager.GetActiveScene().name);
        voice = gameObject.GetComponent<Voice>();
        StartCoroutine(NormalAtk());
        StartCoroutine(Diz());
    }

    void FixedUpdate()
    {
        if (status.canMove)
        {
            Movement();
            SkillInput();
        }
        //NormalAtk();
    }
}

/// <summary>
/// 紀錄玩家的目前參數
/// </summary>
[System.Serializable]
public class PlayerStatus
{
    public int Hp;
    public bool canMove;
    public List<SkillStatus> skill = new List<SkillStatus>();
    public void init(int maxHp, FoodSkill[] skillTable) {
        Hp = maxHp;
        canMove = true;
        
        for(int i = 0; i< skillTable.Length; i++)
        {
            skill.Add(new SkillStatus());
            skill[i].cd_remain = 0;
            skill[i].count = skillTable[i].initCount;
        }
    }

    /// <summary>
    /// pass remain cool down time to UI
    /// </summary>
    /// <param name="skillIndex"></param>
    /// <returns></returns>
    public float GetRemainCd(int skillIndex)
    {
        return skill[skillIndex].cd_remain;
    }
    /// <summary>
    /// 計算冷卻時間
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cd"></param>
    /// <returns></returns>
    public IEnumerator CoolDownSkill(int index, float cd) {
        skill[index].cd_remain = cd;
        while (skill[index].cd_remain > 0)
        {
            yield return new WaitForEndOfFrame();
            skill[index].cd_remain -= Time.deltaTime;

        }
        skill[index].cd_remain = 0;
        yield return null;
    }
}

/// <summary>
/// 紀錄玩家各技能目前的狀態(冷卻過幾秒、現在是否可用)
/// </summary>
[System.Serializable]
public class SkillStatus {
    public float cd_remain;
    public int count;
}