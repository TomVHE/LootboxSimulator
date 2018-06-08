using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGeneration : MonoBehaviour {

	public List<string> prefixes = new List<string> ();
	public List<string> suffixes = new List<string> ();
	public List<GameObject> prefabs = new List<GameObject> ();
	public int numberOfItems = 10;

	[HideInInspector]
	public List<Item> items = new List<Item> ();

	public void Generation () {
		for (int i = 0; i < numberOfItems; i++) {
			GameObject item = prefabs[Random.Range (0, prefabs.Count)];
			items.Add (new Item ("", item, Item.Rarity.Common));
		}
	}
}

[ExecuteInEditMode]
public class Chance {
	[Range (0f, 100f)]
	public float common = 20f;
	[Range (0f, 100f)]
	public float uncommon = 20f;
	[Range (0f, 100f)]
	public float rare = 20f;
	[Range (0f, 100f)]
	public float exotic = 20f;
	[Range (0f, 100f)]
	public float legendary = 20f;

	public void Update () {

	}
}

public class Item {
	public string name;
	public GameObject prefab;
	public enum Rarity {
		Common,
		Uncommon,
		Rare,
		Exotic,
		Legendary
	}
	public Rarity rarity;
	//[HideInInspector]
	public int value;

	public Item (string _name, GameObject _prefab, Rarity _rarity) {
		name = _name;
		prefab = _prefab;
		rarity = _rarity;
		CalculateValue ();
	}

	public void CalculateValue () {
		switch (rarity) {
			case Rarity.Common:
				value = Random.Range (1, 11);
				break;
			case Rarity.Uncommon:
				value = Random.Range (15, 21);
				break;
			case Rarity.Rare:
				value = Random.Range (25, 31);
				break;
			case Rarity.Exotic:
				value = Random.Range (35, 41);
				break;
			case Rarity.Legendary:
				value = Random.Range (45, 51);
				break;
		}
	}
}