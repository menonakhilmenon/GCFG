using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GCFG
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField]
        private Slider healthSlider = null;

        [SerializeField]
        private bool useLocal = false;

        [SerializeField]
        private bool useText = false;

        [HideIf(nameof(useLocal))]
        [SerializeField]
        private Health health = null;

        [ShowIf(nameof(useText))]
        [SerializeField]
        private TMPro.TMP_Text healthText = null;



        private void OnEnable()
        {
            if (useLocal) 
            {
                health = PlayerManager.instance.LocalPlayerObject.health;
            }
            healthSlider.minValue = 0f;
            UpdateHealth();
        }

        public void UpdateHealth() 
        {
            var healthCurr = Mathf.RoundToInt(health.currentHealth);
            var healthMax = Mathf.RoundToInt(health.MaxHealth);
            healthSlider.maxValue = healthMax;
            healthSlider.value = healthCurr;
            if (useText)
            {
                healthText.text = $"{healthCurr} / {healthMax}";
            }
        }

    }
}