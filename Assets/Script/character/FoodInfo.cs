using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInfo : MonoBehaviour
{
    /// <summary>
    /// some value like attack , cooldown...
    /// </summary>
    public FoodSkill info;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDes());
    }

    IEnumerator AutoDes() {
        yield return new WaitForSeconds(info.destoryTime);
        Destroy(gameObject);
        yield return null;
    }

}
