using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateBaceCamera : MonoBehaviour{

    public float rotateSpeed = 10.0f;

    private Transform player;

    // Start is called before the first frame update
    void Start( ){
        player = GameObject.FindGameObjectWithTag( "Player" ).transform;

        if( player == null ){
            player = transform;
        }
    }

    // Update is called once per frame
    void Update( ){
        float vertical = Input.GetAxis( "Vertical" );
        float horizontal = Input.GetAxis( "Horizontal" );

        //�A�i���O�X�e�B�b�N�̂������z�肵�ā}0.01�ȉ����͂���
        if( Mathf.Abs( horizontal ) * Mathf.Abs( vertical ) > 0.1f ){
            //�J�������猩���v���C���[�̕����x�N�g��
            Vector3 camToPlayer = player.position - Camera.main.transform.position;

            //��/2 - atan2( x, y ) == atan2( y, x )
            float inputAngle = Mathf.Atan2( horizontal, vertical ) * Mathf.Rad2Deg;
            float cameraAngle = Mathf.Atan2( camToPlayer.x, camToPlayer.z ) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler( 0, inputAngle + cameraAngle, 0 );

            //deltaTime��p���邱�Ƃŏ�ɂ��̂̑��x�ɂȂ�
            player.rotation = Quaternion.Slerp( player.rotation, targetRotation, Time.deltaTime * rotateSpeed );
        }
    }
}
