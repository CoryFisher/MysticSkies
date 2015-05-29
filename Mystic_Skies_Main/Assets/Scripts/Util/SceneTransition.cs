using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
	private const float kSpawnOffset = 2.0f;
	public int transitionPointIndex;
	public bool loadSceneOnCollision = true;
	public Scenes sceneToload;

	void Start()
	{
		if(SceneManager.GetTransitionPointIndex() == this.transitionPointIndex)
		{
			PlayerManager.SetPlayerPositon (transform.position + (transform.forward * kSpawnOffset) + (transform.up * kSpawnOffset));
			PlayerManager.SetPlayerForward (transform.forward);
		}
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		if(mr)
		{
			mr.enabled = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.CompareTag("Player"))
		{
			SceneManager.SetTransitionPointIndex(this.transitionPointIndex);
			if(loadSceneOnCollision)
			{
				SceneManager.SetCurrentScene(sceneToload);
				print ("[SceneTransition] Loading gameplay scene: " + SceneManager.CurrentScene().ToString());
				InputManager.SetAcceptingInput (true);
				PlayerManager.SetPlayerAndCameraActive(true);
				SceneManager.LoadSceneDestructive (SceneManager.CurrentScene());
				UIManager.Activate (UICanvasTypes.HUD);
			}
			else
			{
				SceneManager.SetCurrentScene(sceneToload);
			}
		}
	}
}