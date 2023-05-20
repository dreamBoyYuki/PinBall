using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }
    
    void Update()
    {
        //左フリッパーの動作
        LeftFripperMove();

        //右フリッパーの動作
        RightFripperMove();
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    /// <summary>
    /// 左フリッパーの動作
    /// </summary>
    private void LeftFripperMove()
    {
        //タグが左フリッパーでなければ何もしない
        if (tag != "LeftFripperTag") return;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //左フリッパーをフリック位置に
            SetAngle(flickAngle);
            return;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //左フリッパーをデフォ位置に
            SetAngle(defaultAngle);
            return;
        }

        Touch[] touches = Input.touches;

        for (int i = 0; i < touches.Length; i++)
        {
            if (touches[i].phase == TouchPhase.Began
                && touches[i].position.x <= (Screen.width / 2.0f))
            {
                //左フリッパーをフリック位置に
                SetAngle(flickAngle);
                return;
            }
            else if (touches[i].phase == TouchPhase.Ended)
            {
                //左フリッパーをデフォ位置に
                SetAngle(defaultAngle);
                return;
            }
        }
    }

    /// <summary>
    /// 右フリッパーの動作
    /// </summary>
    private void RightFripperMove()
    {
        //タグが右フリッパーでなければ何もしない
        if (tag != "RightFripperTag") return;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //右フリッパーをフリック位置に
            SetAngle(flickAngle);
            return;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //右フリッパーをフリック位置に
            SetAngle(defaultAngle);
            return;
        }

        Touch[] touches = Input.touches;

        for (int i = 0; i < touches.Length; i++)
        {
            if (touches[i].phase == TouchPhase.Began
                && touches[i].position.x > (Screen.width / 2.0f))
            {
                //右フリッパーをフリック位置に
                SetAngle(flickAngle);
                return;
            }
            else if (touches[i].phase == TouchPhase.Ended)
            {
                //右フリッパーをフリック位置に
                SetAngle(defaultAngle);
                return;
            }
        }
    }

}

