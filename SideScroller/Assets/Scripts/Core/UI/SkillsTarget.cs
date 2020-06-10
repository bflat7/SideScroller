using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillsTarget : MonoBehaviour
{
    public int Id;
    private Toggle _SkillToggle;

    private void Awake()
    {
        _SkillToggle = GetComponent<Toggle>();
    }

    public void UpdateToggle()
    {
        _SkillToggle.isOn = true;
    }
}
