using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{

    [NonSerialized]
    public SkillNode Skills;

    [SerializeField]
    private TextAsset _SkillsJson;
    [SerializeField]
    private RectTransform _CursorTransform;
    private UIHandler mainUIHandler;
    private List<SkillsTarget> _Toggles;
    private GameObject _GameObject;

    private void Awake()
    {
        mainUIHandler = GetComponentInParent<UIHandler>();
        _GameObject = this.gameObject;
        Skills = JsonUtility.FromJson<SkillNode>(_SkillsJson.text);
        _Toggles = this.GetComponentsInChildren<SkillsTarget>().ToList();
        LoadSkills(Skills, null);
    }

    public void MoveCursor(RectTransform transform)
    {
        var pos = transform.localPosition;
        _CursorTransform.localPosition = new Vector2(pos.x, pos.y + 2.11648f);
    }

    private void LoadSkills(SkillNode current, SkillNode parent)
    {
        current.Parent = parent;
        if (current.Active)
        {
            _Toggles.FirstOrDefault(a => a.Id == current.Id);
            _Toggles.FirstOrDefault(toggle => toggle.Id == current.Id)?.UpdateToggle();
        }
        foreach (var child in current.Children)
        {
            LoadSkills(child, current);
        }
    }
    public void SkillClicked(SkillsTarget skillTarget)
    {
        var clickedSkill = Skills.FindNode(skillTarget.Id);
        if (clickedSkill.Active == false && clickedSkill.Parent.Active)
        {
            clickedSkill.Active = true;
            skillTarget.UpdateToggle();
        }
    }
    public void BackClicked()
    {
        mainUIHandler.WakeGameMenu();
    }
}
