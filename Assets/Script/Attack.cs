using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public SpriteRenderer renderer;
    Rigidbody2D player;
    Transform parentTransform;
    private Vector3 lastPosition;

    public string SwordAtk = "sword";
    public string SwordAtkL = "swordL";

    string nowAnimation = "";
    string oldAnimation = "";

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        parentTransform = transform.parent.transform;
        renderer = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 rightPos = new Vector3(0.4f, 0, 0);
        Vector3 rightPosReverse = new Vector3(-0.4f, 0, 0);
        
        //�����̽��ٰ� �Է� ���� �� ����Ǵ� �ڵ�
        // ������ ������ �������� ������ Ȯ���ؼ� �� ���ǽĿ� ���� �ִϸ��̼� ����ϱ� 0516
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider ������Ʈ Ȱ��ȭ
            if(currentPosition.x >= transform.position.x)
            {
                nowAnimation = SwordAtk;
                GetComponent<Animator>().Play(nowAnimation);

            }
            else if(currentPosition.x <= transform.position.x)
            {
                nowAnimation = SwordAtkL;
                GetComponent<Animator>().Play(nowAnimation);
            }

            //renderer.flipY = true;
        }
        // �����̽����� �Է��� ���� ���� �� ����Ǵ� �ڵ�
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;  // Collider ������Ʈ ��Ȱ��ȭ
            //renderer.flipY = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = parentTransform.position + rightPosReverse;
            //renderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = parentTransform.position + rightPos;
            //renderer.flipX = false;
        }

        if(oldAnimation != nowAnimation)
        {
            nowAnimation = oldAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }
    }

    void LateUpdate() 
    {
        
        // �θ� ������Ʈ�� ��ġ�� ���󰡵��� �ڽ� ������Ʈ�� ��ġ�� ������Ʈ�մϴ�.
        //transform.position = parentTransform.position;
    }
    
}
