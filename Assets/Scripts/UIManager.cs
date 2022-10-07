using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] RunTimeData _runtimedata;
    [SerializeField] TextMeshProUGUI _MoneyText;
    [SerializeField] TextMeshProUGUI _HealthText;
    [SerializeField] TextMeshProUGUI _LoseText;
    [SerializeField] TextMeshProUGUI _Damage;
    [SerializeField] Player player;
    // Update is called once per frame
    void Update()
    {
        int hp = player.getHealth();
        _HealthText.text = "Health: " + hp;
        _MoneyText.text = "Money: "  + _runtimedata.CurrentCash;
        _Damage.text = "DMG: " + _runtimedata.CurrentFoodDamage;
        if (hp <= 0)
        {
            _LoseText.text = "You Lost!";
        }
    }
}
