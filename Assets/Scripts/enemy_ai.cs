using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Behaviors {Passive, Active};

public class enemy_ai : MonoBehaviour
{

    Behaviors aiBehaviors = Behaviors.Passive;
	Vector3 Destination;
	Vector3 Destination_Player;
	float Distance;
	Vector3[] Waypoints = new Vector3[2];
	public float Left_Waypoint;
	public float Right_Waypoint;
    int current_Waypoint = 0;
	public GameObject player;
    public float passiveSpeed;
	float activeSpeed;
	float speed;
	public bool Type_Range;
	public bool Type_Asmodeus;

	public GameObject Projectile;
	float remainingTime = 0;

    void Start()
    {
		Vector3 Waypoint_1 = new Vector3(Left_Waypoint, gameObject.transform.position.y, gameObject.transform.position.z);
		Vector3 Waypoint_2 = new Vector3(Right_Waypoint, gameObject.transform.position.y, gameObject.transform.position.z);
		Waypoints[0] = Waypoint_1;
		Waypoints[1] = Waypoint_2;

		activeSpeed = passiveSpeed + 0.5f;
    }

    void Update()
    {
		if (remainingTime > 0) {
			remainingTime -= Time.deltaTime;
		}

        switch(aiBehaviors)
        {
            case Behaviors.Passive:
				speed = passiveSpeed;
                Passive();
                break;
            case Behaviors.Active:
				speed = activeSpeed;
                Active();
                break;
        }

		transform.position = Vector3.MoveTowards(gameObject.transform.position, Destination, speed * Time.deltaTime);
    }

	//Enemy travels between waypoints
    void Passive()
	{
		Destination_Player = player.transform.position;
		Distance = Vector3.Distance(gameObject.transform.position, Destination_Player);

		if(Distance <= 2.00f)
		{
			aiBehaviors = Behaviors.Active;
		}
		else
		{
			Waypoints_Search();
		}
	}

	//Enemy follows and atttacks the player
    void Active()
    {
        Distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
		if(Type_Range)
		{
			if(Distance > 6.00f)
			{
				aiBehaviors = Behaviors.Passive;
			}else if(remainingTime <= 0)
			{
				Ranged_Enemy();
				remainingTime = 2;
			}
		}else if(Type_Asmodeus)
		{
			if(Distance > 5.00f)
			{
				aiBehaviors = Behaviors.Passive;
			}else
			{
				Destination = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
			}
		}else if(Distance > 3.00f)
        {
			aiBehaviors = Behaviors.Passive;
		}else
		{
            Destination = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
        }
	}

	//Allows the wizard enemy to shoot a projectile at the player
	void Ranged_Enemy()
	{
		Vector3 Projectile_Spawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
		GameObject newProjectile = Instantiate(Projectile, Projectile_Spawn, gameObject.transform.rotation) as GameObject;
		Rigidbody2D bulletRig = newProjectile.GetComponent<Rigidbody2D>();
		if(player.transform.position.x - gameObject.transform.position.x <= 0)
		{
			bulletRig.velocity = new Vector2(-4.0f, 0.0f);
		} else
		{
			bulletRig.velocity = new Vector2(4.0f, 0.0f);
		}
		Destroy(newProjectile, 5);
	}

	//The method for switching waypoints
    void Waypoints_Search()
    {
		Distance = Vector3.Distance(gameObject.transform.position, Waypoints[current_Waypoint]);
		if(Distance > 0.5f)
		{
			Destination = Waypoints[current_Waypoint];
		}
		else
		{
			if(current_Waypoint == 0)
			{
				current_Waypoint = 1;
			}
			else
			{					
                current_Waypoint = 0;
			}
            Destination = Waypoints[current_Waypoint];
		}
    }
}
