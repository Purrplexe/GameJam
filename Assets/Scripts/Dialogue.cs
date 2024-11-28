using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Dialogue
{
    public int id;
    public Dictionary<string, int> answerNavigation;
    public string text;
    public Sprite character1;
    public Sprite character2;
    public bool char1Talking;

}
[CreateAssetMenu(fileName = "new Dialogue", menuName = "Dialogue/DialogueFlow")]
public class DialogueFlow : ScriptableObject
{
    public List<Dialogue> Dialogues;
}
