using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour{

    public GameObject target;
    public float followSpeed;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start( ){
    }

	private void LateUpdate( ){
        transform.position += target.transform.position - targetPos;
        targetPos = target.transform.position;

        // �}�E�X�̉E�N���b�N�������Ă����
        if ( Input.GetMouseButton( 1 ) ) {
            // �}�E�X�̈ړ���
            float mouseInputX = Input.GetAxis( "Mouse X" );
            float mouseInputY = Input.GetAxis( "Mouse Y" );
            // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
            transform.RotateAround( targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f );
            // �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
            transform.RotateAround( targetPos, transform.right, mouseInputY * Time.deltaTime * 200f );
        }
    }
}
