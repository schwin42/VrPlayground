using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class CharacterInput : MonoBehaviour {

	NavMeshAgent agent;

	public ThirdPersonCharacter character;



	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		character = GetComponent<ThirdPersonCharacter>();

		Component[] components = GetComponents(typeof(Component));
		foreach (Component component in components) {
			print("Component: " + component.GetType().ToString());
		}

		print("character: " + (GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>() == null ? "null" : "thing"));


		agent.updateRotation = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				agent.SetDestination(hit.point);
			}
		}

//		if (agent.remainingDistance > agent.stoppingDistance) {
//			character.Move(agent.desiredVelocity, false, false);
//		} else {
//			character.Move(Vector3.zero, false, false);
//		}
	}
}
