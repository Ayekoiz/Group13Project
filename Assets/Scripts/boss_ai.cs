using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss_Behaviors {Passive, Active, Shoot};

public class boss_ai : MonoBehaviour
{

    Boss_Behaviors aiBehaviors = Boss_Behaviors.Passive;
	Vector3 Destination;
	Vector3 Destination_Player;
	float Distance;
	Vector3[] Waypoints = new Vector3[2];
	public float Left_Waypoint;
	public float Right_Waypoint;
    int current_Waypoint = 0;
	public GameObject player;
	public float speed;

	public GameObject Projectile;
	float remainingTime = 0;

    void Start()
    {
		Vector3 Waypoint_1 = new Vector3(Left_Waypoint, gameObject.transform.position.y, gameObject.transform.position.z);
		Vector3 Waypoint_2 = new Vector3(Right_Waypoint, gameObject.transform.position.y, gameObject.transform.position.z);
		Waypoints[0] = Waypoint_1;
		Waypoints[1] = Waypoint_2;
    }

    void Update()
    {
		if (remainingTime > 0) {
			remainingTime -= Time.deltaTime;
		}

        switch(aiBehaviors)
        {
            case Boss_Behaviors.Passive:
                Passive();
                break;
            case Boss_Behaviors.Active:
                Active();
                break;
            case Boss_Behaviors.Shoot:
                Shoot();
                break;
        }

    }

	//Boss waits for player
    void Passive()
	{
		Destination_Player = player.transform.position;
		Distance = Vector3.Distance(gameObject.transform.position, Destination_Player);
        
        if(Distance < 7.00f)
        {
            aiBehaviors = Boss_Behaviors.Active;
        }
	}

	//Boss travels between waypoints
    void Active()
    {
        Distance = Vector3.Distance(gameObject.transform.position, Waypoints[current_Waypoint]);
		if(Distance > 0.5f)
		{
            if(remainingTime > 0)
            {
                Destination = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
            }
            else if(remainingTime <= 0)
            {
			    Destination = Waypoints[current_Waypoint];
            }
		}
		else
		{
            if(current_Waypoint == 0)
			{
				current_Waypoint = 1;
                aiBehaviors = Boss_Behaviors.Shoot;
			}
			else
			{					
                current_Waypoint = 0;
                aiBehaviors = Boss_Behaviors.Shoot;
			}
		}

        transform.position = Vector3.MoveTowards(gameObject.transform.position, Destination, speed * Time.deltaTime);
	}

    //Boss shoots a projectile at the player when it reaches a waypoint
	void Shoot()
	{
		Vector3 Projectile_Spawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
		GameObject newProjectile = Instantiate(Projectile, Projectile_Spawn, gameObject.transform.rotation) as GameObject;
		Rigidbody2D bulletRig = newProjectile.GetComponent<Rigidbody2D>();
		if(player.transform.position.x - gameObject.transform.position.x <= 0)
		{
			bulletRig.velocity = new Vector2(-8.0f, 0.0f);
		} else
		{
			bulletRig.velocity = new Vector2(8.0f, 0.0f);
		}
		Destroy(newProjectile, 5);

        aiBehaviors = Boss_Behaviors.Active;

        remainingTime = 2;
	}
}