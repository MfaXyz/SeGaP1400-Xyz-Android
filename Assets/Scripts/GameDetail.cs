using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Details
{
    public List<Detail> objectDetails = new List<Detail>();
}


[Serializable]
public struct Detail
{
    public int id;
    public string name;
    public string s1;
    public string s2;
    public string link;
}
