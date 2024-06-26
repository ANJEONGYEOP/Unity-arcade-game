using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   [SerializeField]
   private string    nextSceneName;
   [SerializeField]
   private StageData stageData;
   [SerializeField]
   private KeyCode keyCodeAttack = KeyCode.Space;
   private Movement2D movment2D;
   private Weapon weapon;

   private void Awake()
   {
    movment2D = GetComponent<Movement2D>();
    weapon    = GetComponent<Weapon>();
   }

   private void Update()
   {
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");

    movment2D.MoveTo(new Vector3(x, y, 0));
  

   if ( Input.GetKeyDown(keyCodeAttack) )
   {
      weapon.StartFiring();
   }
   else if ( Input.GetKeyUp(keyCodeAttack) )
   {
      weapon.StopFiring();
   }
}
   private void LateUpdate()
   {
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
   }
   
   public void OnDie()
   {
      //if player die, to nextSceneName
      SceneManager.LoadScene(nextSceneName);
   }
}
