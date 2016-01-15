using UnityEngine; 
using System.Collections; 

public class CameraController : MonoBehaviour { 
	public GameObject player; //The offset of the camera to centrate the player in the X axis 
	public float offsetX = -5; //The offset of the camera to centrate the player in the Z axis 
	public float offsetZ = 0; //The maximum distance permited to the camera to be far from the player, its used to make a smooth movement 
	public float offsetY = -12;
	public float maximumDistance = 2; //The velocity of your player, used to determine que speed of the camera 
	public float playerVelocity = 10;

 
	private float movementX;
	private float movementZ;
	private float movementY;
	private float lastPlayerY;


	void Start()
	{
		
		transform.position = new Vector3(
			player.transform.position.x + offsetX, 
			transform.position.y, 
			player.transform.position.z + offsetZ);

		transform.LookAt(player.transform);
		
		lastPlayerY = 0;
	}

 
// Update is called once per frame 
	void Update () { 
		movementX = ((player.transform.position.x + offsetX - this.transform.position.x))/maximumDistance;
		movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z))/maximumDistance; 
		
		print(lastPlayerY);
		
		if(lastPlayerY > player.transform.position.y+0.25)
		{
			print("Last player higher");
			movementY = (this.transform.position.y - (lastPlayerY - player.transform.position.y));
		}
		else if(lastPlayerY < player.transform.position.y-0.25)
		{
			print("Last player lower");
			movementY = (this.transform.position.y + (player.transform.position.y - lastPlayerY));
		}
		else
		{
			print("No Y movement");
			movementY = 0;
		}
		
		this.transform.position += new Vector3((movementX*playerVelocity*Time.deltaTime), (movementY), (movementZ*playerVelocity*Time.deltaTime)); 
		lastPlayerY = player.transform.position.y;
	} 
 } 
