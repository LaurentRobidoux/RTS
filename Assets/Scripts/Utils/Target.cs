using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Target
{
    [SerializeField]
    /// <summary>
    /// World position
    /// </summary>
    public Vector3 Position { get; set; }
    [SerializeField]
    public GameObject GameObject { get; set; }
    public Target(GameObject pGameObject)
    {
        GameObject = pGameObject;
        Position = GameObject.transform.position;
    }
    public Target(Vector3 position)
    {
        Position = position;
    }
    public static implicit operator Vector3(Target reference)
    {
        return reference.Position;
    }
    public static implicit operator GameObject(Target reference)
    {
        return reference.GameObject;
    }
    public static implicit operator Target(Vector3 reference)
    {
        return new Target(reference);
    }
    public static implicit operator Target(GameObject reference)
    {
        return new Target(reference);
    }
    public override string ToString()
    {
       string name=  GameObject!=null?GameObject.name:"None";
        return "Target Name: " + name + " Position : " + Position;
    }
}

