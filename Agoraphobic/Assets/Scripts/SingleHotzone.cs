using UnityEngine;
using System.Collections;

public class SingleHotzone : MonoBehaviour {


    public string zoneName;
    public float zoneHealth;
    public float zoneMaxHealth;
    public float healRate;


    //Systems links
    public PlayerController myPlayer;
    public GameObject other;
    public HotZoneController hzRoot;

    //public Transform speechRoot; //set in inspector, used to determine where speech bubble appears
    
    // Use this for initialization
	void Start () {

        hzRoot = GetComponentInParent<HotZoneController>();

        zoneMaxHealth = hzRoot.hotZoneMaxhealth;
        zoneHealth = hzRoot.hotZoneMaxhealth;
        healRate = hzRoot.hotZoneHealPoints;
        hzRoot.UpdateHotzonePercentage(zoneHealth / zoneMaxHealth);
    }


    private void OnEnable()
    {
        //heals small amount on enable
        if (hzRoot == null) { hzRoot = GetComponentInParent<HotZoneController>(); }
        zoneHealth = Mathf.Min(zoneHealth + healRate, hzRoot.hotZoneMaxhealth);

        //UpdateGui
        hzRoot.UpdateHotzonePercentage(zoneHealth / zoneMaxHealth);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 11)
        { //enemylayer
            other = collision.gameObject;

            EnemyLife enemy = other.GetComponent<EnemyLife>();

            float damage = enemy.meleeDamage;

            takeZoneDamage(damage);
            hzRoot.HotZoneViolated(); //lets the controller know about enemy entering hotzone, for animation/sound effects

            enemy.Die();

        }


    }


    private void takeZoneDamage(float dmg) {

        zoneHealth -= dmg;
        //Update GUI
        hzRoot.UpdateHotzonePercentage(zoneHealth / zoneMaxHealth);

        if (zoneHealth <= 0.0f)
        {
            myPlayer.ZoneDeath(zoneName);
        }





    }











}
