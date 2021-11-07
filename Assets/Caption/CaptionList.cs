using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CaptionList", menuName = "Caption/New CaptionList")]
public class CaptionList : ScriptableObject
{
	public enum strtype
	{		
		caption,
		player,
		sysinfo
	}
	[System.Serializable]
	
	public struct caption
	{
		public strtype type;
		public float sec;
		[TextArea]
		public string str;
	}
	
    public List<caption> sentence = new List<caption>();
}
