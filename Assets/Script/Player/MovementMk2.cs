using UnityEngine;
using System.Collections;

public class MovementMk2 : MonoBehaviour {

	public GameObject feet; //isGrounded Array Start
	private Animator running; //Running and Attacking Animation
	BoxCollider2D playerCollider; //Used for Duck
	Rigidbody2D datRigidBody; //Used For Double Jump
	ParticleSystem teleportParticle;
	int currentJump = 0; //Check If Current Jump Is A Double Jump
	float fallVelocity = 0; //Check Fall damage
	float speed; //Movement Speed
	public float startSpeed = 10f;
	private float jumpForce = 10f;
	public float JumpForce {
		get {
			return jumpForce;
		}
		set {
			jumpForce = value;
		}
	}

 //First Jump Height
	public float doubleJumpForce = 1f; //Double Jump Height
	public bool isGrounded = false; //Check If The Player Is Grounded
	bool checkFall = false; //Make Sure Fall Damage Is Apllied At Right Time
	bool playing; //Pause Movement When Game Is Paused
	SwordDamage sDmg; //Sword Only Damages When Attack is Pressed
	Health health; //Add Fall Damage
	Abilities ability;
	bool floating = false;
	bool climb = false;
	private Menus menu; //Check If Game Is Paused
	float CollideY;
	AudioSource playerAudio;
	private Transform player;
	Vector3 mousePosition;
	
	void Start () {
		playerAudio = GetComponent<AudioSource>();
		ability = (Abilities)FindObjectOfType (typeof(Abilities));
		menu = (Menus)FindObjectOfType (typeof(Menus));
		health = (Health)FindObjectOfType (typeof(Health));
		sDmg = (SwordDamage)FindObjectOfType(typeof(SwordDamage));
		running = GetComponent<Animator> ();
		playerCollider = GetComponent<BoxCollider2D>();
		datRigidBody = GetComponent<Rigidbody2D> ();
		teleportParticle = GetComponent<ParticleSystem> ();
		datRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		datRigidBody.interpolation = RigidbodyInterpolation2D.Extrapolate;
		CollideY = playerCollider.size.y;
		speed = startSpeed;
	}

	
	void Update () {
		playing = menu.GetPlaying ();

		//Draw Check Ground Ray
		Vector3 down = transform.TransformDirection(Vector3.down) * 0.2f;
		Debug.DrawRay(feet.transform.position, down, Color.blue);

		//Add Fall Damage
		if (IsGrounded()) 
		{
			isGrounded = true;
			currentJump = 0;
			if(checkFall)
			{
				if(gameObject.tag == "Player")
				FallDamage(fallVelocity);
			}
		} else 
		{
			isGrounded = false;
			fallVelocity = datRigidBody.velocity.y;
			checkFall = true;
		} 

		//Run Left And Play Animation
		if (Input.GetKey (KeyCode.A) && playing == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			running.SetBool ("RunLeft", true);
			transform.rotation = Quaternion.Euler (0, 180, 0);
		} else
			running.SetBool ("RunLeft", false);
		
		//Run Right And Play Animation
		if (Input.GetKey(KeyCode.D) && playing == true)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			running.SetBool ("RunRight", true);
			transform.rotation = Quaternion.Euler(0f, 0f,0f);
		} else
			running.SetBool ("RunRight", false);

		//Jump And Double Jump
		if (Input.GetKeyDown (KeyCode.Space) && playing == true)
		{
			if(isGrounded && currentJump == 0)
			{
				Jump ();
				currentJump++;
			}
			
			if(!isGrounded && currentJump == 1)
			{
				AirJump ();
				currentJump -= 1;
			}
		}

		//Duck
		if (Input.GetKey (KeyCode.S) && playing == true) {
			playerCollider.size = new Vector2 (playerCollider.size.x, CollideY * 0.5f);
		} else {
			playerCollider.size = new Vector2 (playerCollider.size.x, CollideY);
		}

		//Climb
		if (Input.GetKey(KeyCode.W) && playing == true && climb == true)
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}

		//Attack And Play Animation
		if (Input.GetMouseButtonDown (0) && playing == true) {
			running.Play ("Attack");
			sDmg.CanDamage(true);

		}

		if (ability.activatedIceWraith == true)
			Ascending ();
		if (ability.activatedIceWraith == false && floating == true) {
			Descending ();
		}
	}
	//Check If Player Is Grounded
	bool IsGrounded()
	{
		return Physics2D.Raycast (transform.position, -Vector2.up, 0.6f, LayerMask.GetMask("Ground"));
	}
	//Jump once
	void Jump()
	{
		datRigidBody.velocity = new Vector2(datRigidBody.velocity.x,jumpForce);
	}
	//Double Jump
	void AirJump()
	{
		Vector2 v2 = datRigidBody.velocity;
		v2.y = 0;
		datRigidBody.velocity = v2;
		datRigidBody.AddForce (Vector2.up * doubleJumpForce);
	}
	//Fall Damage
	void FallDamage(float fall)
	{
		fall = Mathf.Round(fall);
		if(fall < -26)
		{
			health.Damage((int)(fall+26)*-1);
		}
		checkFall = false;
	}
	void Ascending(){
		if(floating == false)
		running.Play ("Ascending");
	}
	void Floating(){
		running.SetBool("Floating",true);
		floating = true;
	}
	void Descending(){
		running.SetBool("Floating",false);
		floating = false;
	}
	void Damage(int amount){
		health.Damage (amount);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ladder") {
			climb = true;
			datRigidBody.gravityScale = 0;
			Vector2 v2 = datRigidBody.velocity;
			v2.y = 0;
			datRigidBody.velocity = v2;

		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ladder") {
			climb = false;
			datRigidBody.gravityScale = 5;
			
		}
	}
	void StopSound()
	{
		playerAudio.Stop ();
		sDmg.CanDamage (false);
	}
	void PlaySound()
	{
		playerAudio.clip = Resources.Load ("Audio/Sword/Draw") as AudioClip;
		if(!playerAudio.isPlaying){
			playerAudio.Play();
		}
	}
	public void PlayTeleport()
	{
		teleportParticle.Play ();
	}
	public void SetMovement(float value)
	{
		StartCoroutine ("ReduceSpeed",value);

	}
	public void ReturnMovement()
	{
		StartCoroutine ("IncreaseSpeed",startSpeed);
	}
	IEnumerator ReduceSpeed(float value){
		for (float i = speed; i > value; i--) {
			yield return(new WaitForSeconds (0.15f));
			speed -= 1;
		}
	}
	IEnumerator IncreaseSpeed(float value){
		for (float i = speed; i < value; i++) {
			yield return(new WaitForSeconds (0.15f));
			speed += 1;
		}
	}
	void SloMo(){
		Time.timeScale = 0.3F;
	}
	void RemoveSloMo(){
		Time.timeScale = 1F;
	}
	public void PlayIceShard(){
		running.Play ("IceShard");
	}
	void ShootIceShard(){
		ability.ShootShard ();
	}
	public void PlayAvalanche(){
		running.Play ("Avalanche");
	}
	public void PlayTeleportAnimation(){
		running.Play ("Teleport");
	}
	void Teleport(){
		ability.Teleport ();
	}
	void RemoveTeleportEffects(){
		ability.RemoveTeleportEffects ();
	}

}




