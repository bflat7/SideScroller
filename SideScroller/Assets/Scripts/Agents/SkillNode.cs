using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillNode
{
    [SerializeField]
    public int Id;
    [SerializeField]
    public string Name;
    [SerializeField]
    public string Description;
    [SerializeField]
    public List<SkillNode> Children;
    [SerializeField]
    public bool Active;
    [NonSerialized]
    public SkillNode Parent;
    public SkillNode FindNode(int id)
    {
        if (id == Id)
            return this;

        SkillNode path = null;
        foreach (var child in Children)
        {
            if (child.Id == id)
                return child;
            else if (child.Id < id)
            {
                path = child;
            }
            else if (child.Id > id)
            {
                return path == null ? child.FindNode(id) : path.FindNode(id);
            }
        }
        if (path != null)
            return path.FindNode(id);
        else
            return null;
    }
}
