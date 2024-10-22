using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net;
using UnityEngine;


=======
using UnityEngine;

>>>>>>> 31613564 (å¼•ã£ã“æŠœãã‚¢ãƒ‹ãƒ¡ãƒ¼ã‚·ãƒ§ãƒ³ã‚’ä½œã‚Šã¾ã—ãŸã€‚å•é¡Œç‚¹ã‚‚ç¢ºèªã§ãã¦ã„ãŸã‚‚ã®ã¯ã™ã¹ã¦è§£æ±ºã—ã¾ã—ãŸã€‚)
public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    void Start()
    {
        p_animator = GetComponent<Animator>();
    }

    private float sec = 0;
<<<<<<< HEAD
    public bool Finish = false; //ƒAƒjƒ[ƒVƒ‡ƒ“‚ğs‚Á‚½‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO
=======
    private bool Fnish = false; //ƒAƒjƒ[ƒVƒ‡ƒ“‚ğs‚Á‚½‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO
>>>>>>> 31613564 (å¼•ã£ã“æŠœãã‚¢ãƒ‹ãƒ¡ãƒ¼ã‚·ãƒ§ãƒ³ã‚’ä½œã‚Šã¾ã—ãŸã€‚å•é¡Œç‚¹ã‚‚ç¢ºèªã§ãã¦ã„ãŸã‚‚ã®ã¯ã™ã¹ã¦è§£æ±ºã—ã¾ã—ãŸã€‚)

    void Update()
    {
        //Fnish‚ªture‚É‚È‚Á‚½‚çŒÜ•bŒã‚Éfalse‚É–ß‚·ˆ—
        sec += Time.deltaTime;
<<<<<<< HEAD
        if (Finish == true)
=======
        if (Fnish = true)
>>>>>>> 31613564 (å¼•ã£ã“æŠœãã‚¢ãƒ‹ãƒ¡ãƒ¼ã‚·ãƒ§ãƒ³ã‚’ä½œã‚Šã¾ã—ãŸã€‚å•é¡Œç‚¹ã‚‚ç¢ºèªã§ãã¦ã„ãŸã‚‚ã®ã¯ã™ã¹ã¦è§£æ±ºã—ã¾ã—ãŸã€‚)
        {
            if (sec >= 5f)
            {

                p_animator.SetBool("PullUp", false);
                p_animator.SetBool("Lift", false);

<<<<<<< HEAD
            
                Finish = false;

                sec = 0;

            }
        }
         
=======
                sec = 0;
            }
        }
>>>>>>> 31613564 (å¼•ã£ã“æŠœãã‚¢ãƒ‹ãƒ¡ãƒ¼ã‚·ãƒ§ãƒ³ã‚’ä½œã‚Šã¾ã—ãŸã€‚å•é¡Œç‚¹ã‚‚ç¢ºèªã§ãã¦ã„ãŸã‚‚ã®ã¯ã™ã¹ã¦è§£æ±ºã—ã¾ã—ãŸã€‚)
    }

    //G‚Á‚½ƒIƒuƒWƒFƒNƒg‚Ìƒ^ƒO‚ªƒJƒu‚¾‚Á‚½ƒXƒy[ƒX‚ğ‰Ÿ‚·‚ÆA
    //ˆø‚Á‚±”²‚­ƒAƒjƒ[ƒVƒ‡ƒ“‚ğÄ¶‚³‚¹‚éŠÖ”
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("kabu"))
        {
<<<<<<< HEAD
            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Joystick1Button1)))//ƒL[ƒ{[ƒh‚ÆƒQ[ƒ€ƒpƒbƒh‚É‘Î‰
=======
            if (Input.GetKey(KeyCode.Space))
>>>>>>> 31613564 (å¼•ã£ã“æŠœãã‚¢ãƒ‹ãƒ¡ãƒ¼ã‚·ãƒ§ãƒ³ã‚’ä½œã‚Šã¾ã—ãŸã€‚å•é¡Œç‚¹ã‚‚ç¢ºèªã§ãã¦ã„ãŸã‚‚ã®ã¯ã™ã¹ã¦è§£æ±ºã—ã¾ã—ãŸã€‚)
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator‚ªtrue‚É‚È‚Á‚½‚çFinish‚àtrue‚ğ“ü‚ê‚é
<<<<<<< HEAD
                Finish = true;
=======
                Fnish = true;
>>>>>>> 31613564 (å¼•ã£ã“æŠœãã‚¢ãƒ‹ãƒ¡ãƒ¼ã‚·ãƒ§ãƒ³ã‚’ä½œã‚Šã¾ã—ãŸã€‚å•é¡Œç‚¹ã‚‚ç¢ºèªã§ãã¦ã„ãŸã‚‚ã®ã¯ã™ã¹ã¦è§£æ±ºã—ã¾ã—ãŸã€‚)
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator‚ªtrue‚É‚È‚Á‚½‚çFinish‚àtrue‚ğ“ü‚ê‚é
                Fnish = true;
            }
        }
    }
}
