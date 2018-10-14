using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quality {Common, Uncommon, Rare, Epic, Legendary}

public static class QualityColors 
{
	private static Dictionary<Quality, string> colors = new Dictionary<Quality, string>()
	{
		{Quality.Common, "#d6d6d6"}, //grey
		{Quality.Uncommon, "#00ff00ff"}, //green
		{Quality.Rare, "#0052cd"}, //blue
		{Quality.Epic, "#cd00c6"},//purple
		{Quality.Legendary, "#e6ad00"} //gold
	};

	public static Dictionary<Quality, string> MyColors
	{
		get{return colors;}
	}

}
