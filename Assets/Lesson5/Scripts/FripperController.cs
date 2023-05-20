using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }
    
    void Update()
    {
        //���t���b�p�[�̓���
        LeftFripperMove();

        //�E�t���b�p�[�̓���
        RightFripperMove();
    }

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    /// <summary>
    /// ���t���b�p�[�̓���
    /// </summary>
    private void LeftFripperMove()
    {
        //�^�O�����t���b�p�[�łȂ���Ή������Ȃ�
        if (tag != "LeftFripperTag") return;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���t���b�p�[���t���b�N�ʒu��
            SetAngle(flickAngle);
            return;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //���t���b�p�[���f�t�H�ʒu��
            SetAngle(defaultAngle);
            return;
        }

        Touch[] touches = Input.touches;

        for (int i = 0; i < touches.Length; i++)
        {
            if (touches[i].phase == TouchPhase.Began
                && touches[i].position.x <= (Screen.width / 2.0f))
            {
                //���t���b�p�[���t���b�N�ʒu��
                SetAngle(flickAngle);
                return;
            }
            else if (touches[i].phase == TouchPhase.Ended)
            {
                //���t���b�p�[���f�t�H�ʒu��
                SetAngle(defaultAngle);
                return;
            }
        }
    }

    /// <summary>
    /// �E�t���b�p�[�̓���
    /// </summary>
    private void RightFripperMove()
    {
        //�^�O���E�t���b�p�[�łȂ���Ή������Ȃ�
        if (tag != "RightFripperTag") return;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //�E�t���b�p�[���t���b�N�ʒu��
            SetAngle(flickAngle);
            return;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //�E�t���b�p�[���t���b�N�ʒu��
            SetAngle(defaultAngle);
            return;
        }

        Touch[] touches = Input.touches;

        for (int i = 0; i < touches.Length; i++)
        {
            if (touches[i].phase == TouchPhase.Began
                && touches[i].position.x > (Screen.width / 2.0f))
            {
                //�E�t���b�p�[���t���b�N�ʒu��
                SetAngle(flickAngle);
                return;
            }
            else if (touches[i].phase == TouchPhase.Ended)
            {
                //�E�t���b�p�[���t���b�N�ʒu��
                SetAngle(defaultAngle);
                return;
            }
        }
    }

}

