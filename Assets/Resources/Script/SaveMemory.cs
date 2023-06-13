using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SaveMemory",menuName ="Persistence")]
public class SaveMemory : ScriptableObject
{
    public int txt_Score = 0;
    public int txt_Star = 0;
    public bool isNext=false;
}
