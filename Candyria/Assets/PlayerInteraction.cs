using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject txt;
    int collected = 0;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    void OnTriggerStay2D(Collider2D trig)
    {
        if (Time.time >= nextAttackTime)
        {
            if (trig.gameObject.tag == "Trapped" && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(trig.gameObject);
                collected++;
                txt.GetComponent<UnityEngine.UI.Text>().text = "Saved : " + collected.ToString();
                Debug.Log("Gummy Freed");
                nextAttackTime = Time.time + 1 / attackRate;
            } 
        }
        
    }
}
