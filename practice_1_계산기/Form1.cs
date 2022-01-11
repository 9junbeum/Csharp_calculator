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
        //결과값 전역변수 선언
        float result = 0;
        float setNumber1 = 0;
        float setNumber2 = 10;
        string oper;


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

        }

        // 연산 버튼 클릭시 발생하는 이벤트
        private void operBtnClick(object sender, EventArgs e)
        {
            Button operBtn = (Button)sender;
            oper = operBtn.Text;//입력한 연산자
            //첫번째 숫자가 없을 때 추가 
            if (setNumber1 == 0)
            {
                setNumber1 = float.Parse(textBox1.Text);
            }
            textBox1.AppendText(oper.ToString());
        }

        
        private void equaBtnClick(object sender, EventArgs e)
        {
            Button operBtn = (Button)sender;
            string text1_string = textBox1.Text;

            switch(oper)
            {
                case "+":
                    result = setNumber1 + setNumber2;
                    break;
                case "-":
                    result = setNumber1 - setNumber2;
                    break;
                case "*":
                    result = setNumber1 * setNumber2;
                    break;
                case "/":
                    result = setNumber1 / setNumber2;
                    break;
                default:
                    MessageBox.Show("연산자가 입력되지 않았습니다.");
                    break;
            }
            textBox2.Clear();
            textBox2.AppendText(result.ToString());
        }

        //초기화 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            result = 0;
            setNumber1 = 0;
            setNumber2 = 0;
            oper = "";
        }

        //한개 지우기 버튼
        private void button1_Click(object sender, EventArgs e)
        {
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
