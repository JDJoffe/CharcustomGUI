using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Healthbar
{
    public class HealthBar : MonoBehaviour
    {
       
        //max player health
        public float maxHealth;
        // player current health
        public float currentHealth;
    
        [Header("Reference to UI slider")]
        //reference to slider
        public Slider healthSlider;

        //reference to fill
        public Image healthFill;


        // Update is called once per frame
        void Update()
        {
            //currenthealth divided by maxhealth to make it 0
            healthSlider.value = Mathf.Clamp01(currentHealth / maxHealth);

            //you dead
            if (currentHealth <= 0 && healthFill.enabled)
            {
                //dead = no filled bar
                healthFill.enabled = false;
                Debug.Log("you dead");
            }
            if (!healthFill.enabled && currentHealth > 0)
            {
                //if alive you bar is there
                healthFill.enabled = enabled;
                Debug.Log("you alive");
            }
           
            
        }
    }
}
