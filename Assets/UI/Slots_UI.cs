﻿using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{

    public Image itemIcon;
    public TextMeshProUGUI amountText;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null) {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            amountText.text = slot.amount.ToString();
        }
    }

    public void ClearSlot()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        amountText.text = "";
    }
}
