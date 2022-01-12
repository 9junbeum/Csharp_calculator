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
        float result = 0.0f;
        float num1 = 0.0f;        //저장된 숫자
        float num2 = 0.0f;        //새로 입력받은 숫자
        string oper = "";         //입력받은 연산자
        int oper_count = 0;       //연산자 개수
        int[] index_of_oper;

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

            //첫번 째 textbox에 보여준다.
            textBox1.AppendText(numBtn.Text);
        }

        // 연산 버튼 클릭시 발생하는 이벤트
        private void operBtnClick(object sender, EventArgs e)
        {
            Button operBtn = (Button)sender;

            //index를 저장.
            index_of_oper[oper_count] = textBox1.TextLength;
            oper_count++;
            textBox1.AppendText(operBtn.Text.ToString());
        }

        
        private void equaBtnClick(object sender, EventArgs e)
        {
            Button equaBtn = (Button)sender;
            string s = textBox1.Text;
            string sub = "";

            if(index_of_oper == null)
            {
                MessageBox.Show("연산자가 없습니다.");
            }
            else if(textBox1 == null)
            {
                MessageBox.Show("아무것도 입력되지 않았습니다.");
            }

            //parsing
            for(int i = 0;i<textBox1.TextLength ;i++)
            {
                //문자열이면
                if(index_of_oper.Contains(i))
                {
                    if(num1 == 0)
                    {
                        num1 = Convert.ToSingle(sub);
                    }
                    else
                    {
                        num2 = Convert.ToSingle(sub);
                        
                    }
                    sub = "";
                }
                else
                {
                    sub.Append(s[i]);
                }
            }

            
            switch (oper)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    MessageBox.Show("연산자가 잘못 되었 습니다.");
                    break;
            }
            textBox2.Clear();
            textBox2.AppendText(result.ToString());
            setNumber1 =  Convert.ToSingle(textBox2.Text);
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
            //지우려고 하는 것이 연산자이면,
            if(index_of_oper.Contains(textBox1.TextLength - 1))
            {
                index_of_oper[--oper_count] = 0;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
