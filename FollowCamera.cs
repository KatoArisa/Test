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

        // マウスの右クリックを押している間
        if ( Input.GetMouseButton( 1 ) ) {
            // マウスの移動量
            float mouseInputX = Input.GetAxis( "Mouse X" );
            float mouseInputY = Input.GetAxis( "Mouse Y" );
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround( targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f );
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround( targetPos, transform.right, mouseInputY * Time.deltaTime * 200f );
        }
    }
}
