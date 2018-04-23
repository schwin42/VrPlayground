using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent (typeof(NavMeshAgent))]
[RequireComponent (typeof(ThirdPersonCharacter))]
public class Character : MonoBehaviour
{

	//	[SerializeField] float awarenessRadius = 15.0f;

	enum AgentState
	{
		Idle = 0,
		Moving = 1,
		Attacking = 2,
	}

	NavMeshAgent navAgent;
	ThirdPersonCharacter thirdPersonCharacter;
	ThreatenedRegion threatenedRegion;

	AgentState currentState = AgentState.Idle;

	Character target = null;


	//Bookkeeping
	public bool isInPlay = false;

	void Awake ()
	{
		navAgent = GetComponent<NavMeshAgent> ();
		thirdPersonCharacter = GetComponent<ThirdPersonCharacter> ();
		threatenedRegion = GetComponentInChildren<ThreatenedRegion> ();
	}

	IEnumerator DelayedStart() {
		yield return new WaitForSeconds (0.1f);
		GameController.RegisterCharacter (gameObject, this);


	}

	// Use this for initialization
	void Start ()
	{
		navAgent.updateRotation = false;
		StartCoroutine (DelayedStart ());
	}

	public void OnReady() {
		isInPlay = true;
		threatenedRegion.Initialize (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (currentState) {
		case AgentState.Idle:
			//Attack threatened creatures if any
			if (!threatenedRegion.IsEmpty) {
//				target = threatenedRegion.ThreatenedGos [0]; //Arbitrarily target the first threatened character
				SetState(AgentState.Attacking);
			}

			//Attempt to locate closest opponent
			float minDistance = Mathf.Infinity;
			foreach (KeyValuePair<GameObject, Character> pair in GameController.activeCharactersByGo) {
				if (pair.Value == this)
					continue; //Do not target self
				float sqrDistance = (pair.Value.transform.position - transform.position).sqrMagnitude;
				if (sqrDistance < minDistance) {
					target = pair.Value;
					minDistance = sqrDistance;
				}

				if (target != null) {
					//Target acquired
					SetState (AgentState.Moving);
				}
			}

			break;
		case AgentState.Moving:
			//Validate target
			if (target.isInPlay) {
				if (!threatenedRegion.IsEmpty) {
					SetState (AgentState.Attacking);
				} else {
					navAgent.SetDestination (target.gameObject.transform.position);
					thirdPersonCharacter.Move (navAgent.desiredVelocity, false, false); 
				}
			} else {
				SetState (AgentState.Idle);
			}


			break;
		case AgentState.Attacking:
			//Check if current attack is finished

				//If so, check if box is still threatened

					//If so, continue attack

					//If not, switch to idle
			break;

		}
	}

	void SetState (AgentState state) {
		if (currentState == state) return;

		currentState = state;

		switch (currentState) {
		case AgentState.Idle:
			//Do nothing
			thirdPersonCharacter.Move (Vector3.zero, false, false);

			break;
		case AgentState.Moving:
			navAgent.SetDestination (target.gameObject.transform.position);
			thirdPersonCharacter.Move (navAgent.desiredVelocity, false, false);
			break;
		case AgentState.Attacking:
			thirdPersonCharacter.Move (Vector3.zero, false, false);
			thirdPersonCharacter.Attack ();
			break;
		default:
			Debug.LogError ("Unexpected state: " + state.ToString ());
			break;
		}
	}


	//		if(Input.GetMouseButtonUp(0)) {
	//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	//			RaycastHit hit;
	//			if(Physics.Raycast(ray, out hit)) {
	//				navAgent.SetDestination(hit.point);
	//			}
	//		}
	//
//			if (navAgent.remainingDistance > navAgent.stoppingDistance) {
//				print ("moving with " + navAgent.desiredVelocity);
//				character.Move(navAgent.desiredVelocity, false, false);
//			} else {
//				character.Move(Vector3.zero, false, false);
//			}
}
