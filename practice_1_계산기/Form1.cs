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

        int[] index_of_oper = new int[100]; //연산자가 들어있는 index 포함하는 배열
        int index_count = 0;       //연산자 개수
        float[] num_arr = new float[100];   //실수의 문자열
        int num_count = 0;       //숫자 개수
        string[] oper_arr = new string[100];//연산자의 문자열
        int oper_count = 0;     

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
            index_of_oper[index_count] = textBox1.TextLength;
            //textbox에 보여준다.(숫자와 동일)
            textBox1.AppendText(operBtn.Text);
            //연산자의 개수를 세기 위해 count++ 한다.
            index_count++;
        }

        
        private void equaBtnClick(object sender, EventArgs e)
        {
            //임시로 저장하는 sub 
            string sub = "";

            Button equaBtn = (Button)sender;
            //계산전 최종 문자열을 s에 저장한다.
            string s = textBox1.Text;

            //parsing
            for (int i = 0;i <s.Length;i++)
            {
                string c = s.Substring(i,1);
                if (index_of_oper.Contains(i)&&i!=0)
                {
                    //새로운 실수 모양의 문자열을 새로운 배열에 저장해야한다.
                    try
                    {
                        num_arr[num_count] = Convert.ToSingle(sub);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("잘못된 문자열 입니다.");
                    }
                    sub = "";
                    num_count++;
                    //새로운 연산자도 배열에 저장해야한다.
                    oper_arr[oper_count] = s[i].ToString();
                    oper_count++;
                }
                else
                {
                    sub += c;
                }
            }
            //마지막 ^^
            num_arr[num_count] = Convert.ToSingle(sub);

            //calculate
            for (int j = 0;j < index_count ;j++)
            {
                //아직 연산 안했으면
                if(num1 == 0)
                {
                    num1 = num_arr[j];
                }
                else
                {
                    num2 = num_arr[j];
                    switch(oper_arr[j-1])
                    {
                        case "+":
                            num1 += num2; 
                            break;

                        case "-":
                            num1 -= num2;
                            break;

                        case "*":
                            num1 *= num2;
                            break;

                        case "/":
                            num1 /= num2;
                            break;
                    }
                }
            }
            result = num1;
            textBox2.Clear();
            textBox2.AppendText(result.ToString());
        }

        //초기화 버튼
        private void Clear_Click(object sender, EventArgs e)
        {
            //두개의 화면 모두 clear
            textBox1.Clear();
            textBox2.Clear();
            //매개변수 clear
            result = 0;
            num1 = 0;
            num2 = 0;
            index_count = 0;
        }

        //한개 지우기 버튼
        private void erase_Click(object sender, EventArgs e)
        {
            //지우려고 하는 것이 연산자이면, oper_count 한개 낮춰주고 해당 인덱스에 \0 넣음
            if(index_of_oper.Contains(textBox1.TextLength - 1))
            {
                index_of_oper[--index_count] = '\0';
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
