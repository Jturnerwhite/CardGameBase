using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Resources;
using Characters;
using Characters.Classes;
using Cards;
using UI;

public class Actor : MonoBehaviour
{
	public int ID;
	public CharacterClass characterClass;
	public PercentScale PercentPrefab;

	public Character characterStats { get; set; }
	public List<ResourceUI> ourResources { get; set; }

	public void Initialize() {
		ID = this.GetInstanceID();
	}

	void Awake () {
		characterStats = CharacterFactory.Get(characterClass);
		ourResources = new List<ResourceUI>();

		MakeResourceBars();
		Print();
	}

	void Update () {
	}

	private void Print() {
		var resource = characterStats.GetResource();
		Debug.Log(characterStats.Name);
		Debug.Log(characterStats.CardManager.Hand.Count);
		Debug.Log(characterStats.CardManager.Hand.FirstOrDefault().Name);
	}

	private void MakeResourceBars() {
		List<Resource> resources = characterStats.GetAllResources();
		float counter = 1.5f;
		foreach(var resource in resources) {
			MakeResourceUI(resource, counter);
			counter -= 0.36f;
		}
	}

	private void MakeResourceUI (Resource myResource, float counter) {
		var newPercentScale = Instantiate(PercentPrefab) as PercentScale;
		ourResources.Add(new ResourceUI(myResource, this.transform, newPercentScale, counter));
	}
}
