using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Reload : MonoBehaviour
{
    public int MaxAmmo;
    public int RealAmmo;
    public int AmmoReadi;
    public int MaxAmmoReadi;
    public Animator anim;
    public GameObject BulletUI;
    public CameraMove PlauerM;
    public void Start()
    {
        PlauerM = GameObject.Find("Player").GetComponent<CameraMove>();
        BulletUI = GameObject.Find("BulletU");
        if (PlayerPrefs.HasKey(this.gameObject.name + "AR") == true)
        {
            RealAmmo = PlayerPrefs.GetInt(this.gameObject.name + "RA");
            AmmoReadi = PlayerPrefs.GetInt(this.gameObject.name + "AR");
        }
    }
    public void Update()
    {
        PlayerPrefs.SetInt(this.gameObject.name + "RA", RealAmmo);
        PlayerPrefs.SetInt(this.gameObject.name + "AR", AmmoReadi);
        BulletUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "" + AmmoReadi + "/" + RealAmmo;
        if (Input.GetKeyDown(KeyCode.R) && AmmoReadi < MaxAmmoReadi && RealAmmo > 0)
        {
            anim.SetBool("Rel", true);
        }
        if (AmmoReadi > 0 && Input.GetMouseButtonDown(0) == true)
        {
            anim.SetBool("Shot", true);
            AmmoReadi -= 1;
        }
    }
    public void Stop()
    {
        anim.SetBool("Shot", false);
        PlauerM.Outputi = 0f;
    }
    public void Reloa()
    {
        int ras = MaxAmmoReadi - AmmoReadi;
        if (RealAmmo - ras >= 0)
        {
            AmmoReadi += ras;
            RealAmmo -= ras;
            ras = 0;

        }
        else
        {
            AmmoReadi += RealAmmo;
            RealAmmo = 0;
            ras = 0;
        }
        anim.SetBool("Rel", false);
    }
    public void OneBulletReload()
    {
        if (RealAmmo - 1 >= 0)
        {
            AmmoReadi += 1;
            RealAmmo -= 1;
        }
        if (AmmoReadi == MaxAmmoReadi || RealAmmo == 0)
        { 
            anim.SetBool("Rel", false);
        }
    }
}
