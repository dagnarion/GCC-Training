using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCsharps : MonoBehaviour
{
    void Start()
    {
        Player player = new Player("HELLO");
        
    }

    void KeyWord()
    {

    }
}

public class Player
{
    public string name { get; }
    
    public Player(string _name)
    {
        name = _name;
    }
}
