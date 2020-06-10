using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private GameObject Persistent;
    private GameObject SkillTree;
    private GameObject Inventory;
    private GameObject GameMenu;
    private string ActiveMenu = string.Empty;

    private void Awake()
    {
        var children = this.gameObject.GetComponentsInChildren<Transform>();
        Persistent = children.FirstOrDefault(t => t.name == MenuNames.PersistentUI).gameObject;
        SkillTree = children.FirstOrDefault(t => t.name == MenuNames.SkillTreeUI).gameObject;
        Inventory = children.FirstOrDefault(t => t.name == MenuNames.InventoryUI).gameObject;
        GameMenu = children.FirstOrDefault(t => t.name == MenuNames.GameMenuUI).gameObject;

        if (Persistent == null || SkillTree == null || Inventory == null || GameMenu == null)
            throw new System.Exception();

        SkillTree.SetActive(false);
        Inventory.SetActive(false);
        GameMenu.SetActive(false);

    }

    public void SleepActiveMenu()
    {
        switch (ActiveMenu)
        {
            case MenuNames.SkillTreeUI:
                SkillTree.SetActive(false);
                break;
            case MenuNames.InventoryUI:
                Inventory.SetActive(false);
                break;
            case MenuNames.GameMenuUI:
                GameMenu.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void WakeSkillTree()
    {
        SleepActiveMenu();
        ActiveMenu = MenuNames.SkillTreeUI;
        SkillTree.SetActive(true);
    }

    public void WakeInventory()
    {
        SleepActiveMenu();
        ActiveMenu = MenuNames.InventoryUI;
        Inventory.SetActive(true);
    }

    public void WakeGameMenu()
    {
        if (string.IsNullOrEmpty(ActiveMenu))
        {
            Time.timeScale = 0;
        }
        else if (ActiveMenu != MenuNames.GameMenuUI)
            SleepActiveMenu();
        else
        {
            CloseGameMenu();
            return;
        }

        ActiveMenu = MenuNames.GameMenuUI;
        GameMenu.SetActive(true);

    }

    public void CloseGameMenu()
    {
        ActiveMenu = string.Empty;
        GameMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
