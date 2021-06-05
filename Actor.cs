using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Resources;
using Characters;
using Characters.Classes;
using Characters.Enemies;
using Cards;
using UI;

public class Actor : MonoBehaviour
{
	public int ID;
	public CharacterClass CharacterClass;
	public EnemyType EnemyType;

	public ResourceUI ResourceUIPrefab;

	public Canvas Canvas;

	public Character characterStats { get; set; }
	public List<ResourceUI> ourResources { get; set; }

	public void Initialize() {
		ID = this.GetInstanceID();
	}

	void Awake () {
		this.Canvas.worldCamera = Camera.main;

		if(CharacterClass == CharacterClass.None) {
			characterStats = CharacterFactory.Get(EnemyType);
		} else {
			characterStats = CharacterFactory.Get(CharacterClass);
		}

		ourResources = new List<ResourceUI>();
		MakeResourceBars();

		//Print();
	}

	void FixedUpdate () {
		if(characterStats.HP.Amount <= 0) {
			characterStats.HP.Amount = 0;
			Destroy(gameObject);
		}
	}

	private void Print() {
		var resource = characterStats.GetResource();
		Debug.Log(characterStats.Name);
	}

	private void MakeResourceBars() {
		List<Resource> resources = characterStats.GetAllResources();
		float counter = 1.5f;
		foreach(var resource in resources) {
			MakeResourceUI(resource, counter);
			counter -= 0.36f;
		}
	}

	private void MakeResourceUI (Resource resource, float counter) {
		var newResourceUI = Instantiate(ResourceUIPrefab) as ResourceUI;
		newResourceUI.Init(resource);
		newResourceUI.transform.SetParent(transform, false);
		newResourceUI.transform.position = new Vector2((transform.localPosition.x), (transform.localPosition.y + counter));
		ourResources.Add(newResourceUI);
	}

	public void Click() {
		Debug.Log("Actor Clicked");
		var EventManager = Camera.main.GetComponent<EventManager>();
		if(EventManager != null) {
			EventManager.ActorClicked(this);
		}
	}
}
