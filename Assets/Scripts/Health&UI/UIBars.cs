using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBars : MonoBehaviour
{

    //max player health
    public float maxHealth = 10;
    // player current health
    public float curHealth = 10;
    //max player mana
    public float maxMana = 10;
    // player current mana
    public float curMana = 10;
    //max player stamina
    public float maxStamina = 10f;
    // player current stamina
    public float curStamina = 10f;

    [Header("Reference to UI slider")]
    //reference to health slider/fill
    public Slider healthSlider;
    public Image healthFill;
    //reference to mana slider/fill
    public Slider manaSlider;
    public Image manaFill;
    //reference to stamina slider/fill
    public Slider staminaSlider;
    public Image staminaFill;
    




    // Update is called once per frame
    void Update()
    {

        Health();
        Mana();
        Stamina();

    }

    void Health()
    {
        //currenthealth divided by maxhealth to make it 0
        healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);

        //you dead
        if (curHealth <= 0 && healthFill.enabled)
        {
            //dead = no filled bar
            healthFill.enabled = false;
            Debug.Log("you dead");
        }
        if (!healthFill.enabled && curHealth > 0)
        {
            //if alive you bar is there
            healthFill.enabled = enabled;
            Debug.Log("you alive");
        }
    }
    void Mana()
    {
        manaSlider.value = Mathf.Clamp01(curMana / maxMana);
        if (curMana <= 0 && manaFill.enabled)
        {
            //no fill in bar if outta mana
            healthFill.enabled = false;
            Debug.Log("you outta mana");
        }
        if (!manaFill.enabled && curMana > 0)
        {
            //if mana fill is there
            manaFill.enabled = enabled;
            Debug.Log("you have mana");
        }
    }
    void Stamina()
    {
        staminaSlider.value = Mathf.Clamp01(curStamina / maxStamina);
        if (curStamina <= 0 && staminaFill.enabled)
        {
            //no fill in bar if outta stamina
            healthFill.enabled = false;
            Debug.Log("you outta stamina");
        }
        if (!staminaFill.enabled && curStamina > 0)
        {
            //if stamina fill is there
            staminaFill.enabled = enabled;
            Debug.Log("you have stamina");
        }
    }
}
