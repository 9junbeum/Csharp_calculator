using System;
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
        float result = 0.0f;      //결과값
        float num1 = 0.0f;        //저장된 숫자
        float num2 = 0.0f;        //새로 입력받은 숫자
        string oper = "";         //입력받은 연산자
        int oper_count = 0;       //연산자 개수
        int[] index_of_oper = new int[10];
        float[] num_arr = new float[10];
        string[] oper_arr = new string[10];

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

            //textbox에 보여준다.
            textBox1.AppendText(numBtn.Text);
        }

        // 연산 버튼 클릭시 발생하는 이벤트
        private void operBtnClick(object sender, EventArgs e)
        {
            Button operBtn = (Button)sender;

            //연산자의 index를 저장한다.(연산자가 입력되기 전의 textbox의 길이
            index_of_oper[oper_count] = textBox1.TextLength;
            //textbox에 보여준다.(숫자와 동일)
            textBox1.AppendText(operBtn.Text);
            //연산자의 개수를 세기 위해 count++ 한다.
            oper_count++;
        }

        
        private void equaBtnClick(object sender, EventArgs e)
        {
            Button equaBtn = (Button)sender;


        }

        //초기화 버튼
        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            result = 0;
            num1 = 0;
            num2 = 0;
            oper = "";
            oper_count = 0;
            index_of_oper = null; 
        }

        //한개 지우기 버튼
        private void erase_Click(object sender, EventArgs e)
        {
            //지우려고 하는 것이 연산자이면, oper_count 한개 낮춰주고 해당 인덱스에 \0 넣음
            if(index_of_oper.Contains(textBox1.TextLength - 1))
            {
                index_of_oper[--oper_count] = '\0';
            }

            //textbox 관리
            string s = textBox1.Text;
            if(s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "";
            }
            textBox1.Text = s;
        }

    }
}
