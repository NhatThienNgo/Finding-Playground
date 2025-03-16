using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image HealthFull;
    [SerializeField] private Image HealthCurrent;

    private void Start()
    {
        HealthFull.fillAmount = playerHealth.HealthCurrent / 10;
    }

    private void Update()
    {
        HealthCurrent.fillAmount = playerHealth.HealthCurrent / 10;
    }

    
}
