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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider ������Ʈ Ȱ��ȭ
            nowAnimation = SwordAtk;
            GetComponent<Animator>().Play(SwordAtk);
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
            renderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = parentTransform.position + rightPos;
            renderer.flipX = false;
        }
    }

    void LateUpdate() 
    {
        
        // �θ� ������Ʈ�� ��ġ�� ���󰡵��� �ڽ� ������Ʈ�� ��ġ�� ������Ʈ�մϴ�.
        //transform.position = parentTransform.position;
    }
    
}
