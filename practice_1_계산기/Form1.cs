﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice_1_계산기
{
    public partial class Form1 : Form
    {
        //결과값 전역변수 선언
        double result = 0;
        double setNumber1 = 0;
        double setNumber2 = double.NaN;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 숫자 버튼 클릭시 발생하는 이벤트
        private void numBtnClick(object sender, EventArgs e)
        {
            Button numBtn = (Button)sender;
            int number = Convert.ToInt16(numBtn.Text);//입력한 숫자

            textBox1.AppendText(number.ToString());
            //첫번째 수가 아무것도 입력되지 않았을 때
            if (setNumber1 == 0)
            {

            }

            //MessageBox.Show(number + "버튼을 누르셨어요");
        }

        // 연산 버튼 클릭시 발생하는 이벤트
        private void operBtnClick(object sender, EventArgs e)
        {
            Button operBtn = (Button)sender;

            if(!double.IsNaN(setNumber2)) //?
            {
                
            }
        }
        private void equaBtnClick(object sender, EventArgs e)
        {
            Button operBtn = (Button)sender;


            MessageBox.Show(textBox1.Text.ToString());
        }

        //초기화 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        //한개 지우기 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ClearUndo();
        }
    }
}
