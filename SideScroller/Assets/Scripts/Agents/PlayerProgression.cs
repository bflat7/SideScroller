using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField]
    private Text LevelExp;
    [SerializeField]
    private Core _CoreGame;
    private Text XpGain;
    private float XpGrowthMultiplier = 1.5f;
    private float XpGainMultiplier = 1f;


    [HideInInspector]
    public int Experience { get; private set; }
    [HideInInspector]
    public int LevelUp { get; private set; }
    [HideInInspector]
    public int Level { get; private set; }
    public Guid ServiceId => ServiceGuids.Player;

    private void Awake()
    {
        _CoreGame.RegisteredDependencies.Add(ServiceGuids.Player, this);
        Experience = 0;
        LevelUp = 100;
        Level = 1;
        XpGain = LevelExp.GetComponentsInChildren<Text>().FirstOrDefault(c => c != LevelExp);
        XpGain.text = string.Empty;
        UpdateXpLvlUi();
    }

    public void AddXpMultiplier(float additive)
    {
        XpGainMultiplier += additive;
    }

    public void AddXp(int Xp)
    {
        Xp = Mathf.FloorToInt(Xp * XpGainMultiplier);
        StartCoroutine(TransitionXp(Xp));
    }

    public IEnumerator TransitionXp(int Xp)
    {
        for (; Xp >= 0; Xp -=1)
        {
            Experience += 1;
            if (Experience >= LevelUp)
            {
                ++Level;
                LevelUp = LevelUp + Mathf.FloorToInt(LevelUp * XpGrowthMultiplier);
            }
            UpdateXpLvlUi(Xp);
            yield return null;
        }
    }

    private void UpdateXpLvlUi(int? iterativeXpgain = null)
    {
        LevelExp.text = 
$@"Level: {Level}
XP: {Experience}";
        XpGain.text = (iterativeXpgain == null || iterativeXpgain == 0) ?  string.Empty : $@"+{iterativeXpgain}";
    }
}
