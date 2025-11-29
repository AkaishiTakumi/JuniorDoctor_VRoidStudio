using System;
using System.Collections;
using System.Collections.Generic;
using UniGLTF;
using UnityEditor.PackageManager;
using UnityEngine;

public class GunRay: MonoBehaviour
{
    private Ray ray;//‡BRayŒ^‚Ì•Ï”
    public GameObject Explosion;//‡B“G‚ğ“|‚µ‚½‚ÉoŒ»‚³‚¹‚é”š”­
    private int distance = 10000;//‡BRay‚ğ”ò‚Î‚·‹——£
    private RaycastHit hit;//‡BRay‚ª‰½‚©‚É“–‚½‚Á‚½‚Ìî•ñ
    public GameObject Muzzle;//‡BRay‚ğ”­Ë‚·‚éêŠ


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//‡Bƒ}ƒEƒX‚ª¶ƒNƒŠƒbƒN‚³‚ê‚½‚ç 
        {
            Ray ray = new Ray(Muzzle.transform.position, Muzzle.transform.forward);//‡BRay‚ğMuzzle‚ÌêŠ‚©‚ç‘O•û‚É”ò‚Î‚·
            //Ray ray = new Ray(transform.position, transform.forward);//‡BRay‚ğ‚±‚ÌêŠ‚©‚ç‘O•û‚É”ò‚Î‚·
            Debug.DrawRay(ray.origin, ray.direction, Color.red);//‡BRay‚ğÔF‚Å•\¦‚³‚¹‚é

            if (Physics.Raycast(ray, out hit, distance))
            {//‡BRay‚ªdistance‚Ì”ÍˆÍ“à‚Å‰½‚©‚É“–‚½‚Á‚½‚É
                if (hit.collider.tag == "Enemy")//‡B‚à‚µ“–‚½‚Á‚½•¨‚Ìƒ^ƒO‚ªEnemy‚¾‚Á‚½‚ç 
                {
                    Destroy(hit.collider.gameObject);//‡B“–‚½‚Á‚½•¨‚ğÁ‹‚µ‚ÄA
                    Instantiate(Explosion.gameObject, hit.collider.gameObject.transform.position, gameObject.transform.rotation);//‡BRay‚ª“–‚½‚Á‚½êŠ‚É”š”­‚ğ¶¬‚·‚é
                }
            }
        }
    }
}
