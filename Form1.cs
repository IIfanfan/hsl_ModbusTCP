using HslCommunication;
using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslDemo
{
    public partial class Form1 : Form
    {
        private ModbusTcpNet busTcpClient = null;
        public static String m_sIP = "127.0.0.1";//ip设置 
        public static int m_iPort = 502;//端口号
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            busTcpClient = new ModbusTcpNet(m_sIP, m_iPort, 1);
            busTcpClient.AddressStartWithZero = true;
            busTcpClient.DataFormat = HslCommunication.Core.DataFormat.CDAB;

            try
            {
                OperateResult connect = busTcpClient.ConnectServer();
                if (connect.IsSuccess)
                {
                    toolStripStatusLabel1.Text = "连接成功！";
                }
                else
                {
                    toolStripStatusLabel1.Text = "连接失败！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
           // timer1.Enabled = true;
        }
               /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender( OperateResult result, string address )
        {
            if (result.IsSuccess)
            {
                writeListBox( DateTime.Now.ToString( "[HH:mm:ss] " )+":"+address + "写入成功" );
            }
            else
            {
                 writeListBox( DateTime.Now.ToString( "[HH:mm:ss] " )+":"+address +"写入失败"+ result.ToMessageShowString());
            }
        }
          /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>( OperateResult<T> result, string address)
        {
            if (result.IsSuccess)
            {
                writeListBox( DateTime.Now.ToString( "[HH:mm:ss] " ) + ":"+address + "读取成功" +result.Content);
            }
            else
            {
                writeListBox( DateTime.Now.ToString( "[HH:mm:ss] " ) + ":"+address + "读取失败" +result.ToMessageShowString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // float写入
            //0,更新左托盘;2,X坐标；4，Y坐标；6，Z坐标；8，角度Z，10，角度Y；12，角度Z；
            string strAddr1 = "0";
            string strValue1 = "0";
            string strAddr2 = "2";
            string strValue2 = "-2051.399";
            string strAddr3 = "4";
            string strValue3 = "-868.407";
            string strAddr4 = "6";
            string strValue4 = "761.177";
            string strAddr5 = "8";
            string strValue5 = "0.008387";
            string strAddr6 = "10";
            string strValue6 = "-0.999730";
            string strAddr7 = "12";
            string strValue7 = "0.017084";
            try
            {
                 writeResultRender(busTcpClient.Write(strAddr1, float.Parse(strValue1)), strAddr1);
                 writeResultRender(busTcpClient.Write(strAddr2, float.Parse(strValue2)), strAddr2);
                 writeResultRender(busTcpClient.Write(strAddr3, float.Parse(strValue3)), strAddr3);
                 writeResultRender(busTcpClient.Write(strAddr4, float.Parse(strValue4)), strAddr4);
                 writeResultRender(busTcpClient.Write(strAddr5, float.Parse(strValue5)), strAddr5);
                 writeResultRender(busTcpClient.Write(strAddr6, float.Parse(strValue6)), strAddr6);
                 writeResultRender(busTcpClient.Write(strAddr7, float.Parse(strValue7)), strAddr7);
            }
            catch(Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // float写入
            //0,更新右托盘;2,X坐标；4，Y坐标；6，Z坐标；8，角度Z，10，角度Y；12，角度Z；
            string strAddr1 = "0";
            string strValue1 = "1";
            string strAddr2 = "2";
            string strValue2 = "-2051.399";
            string strAddr3 = "4";
            string strValue3 = "-868.407";
            string strAddr4 = "6";
            string strValue4 = "761.177";
            string strAddr5 = "8";
            string strValue5 = "0.008387";
            string strAddr6 = "10";
            string strValue6 = "-0.999730";
            string strAddr7 = "12";
            string strValue7 = "0.017084";
            try
            {
                writeResultRender(busTcpClient.Write(strAddr1, float.Parse(strValue1)), strAddr1);
                writeResultRender(busTcpClient.Write(strAddr2, float.Parse(strValue2)), strAddr2);
                writeResultRender(busTcpClient.Write(strAddr3, float.Parse(strValue3)), strAddr3);
                writeResultRender(busTcpClient.Write(strAddr4, float.Parse(strValue4)), strAddr4);
                writeResultRender(busTcpClient.Write(strAddr5, float.Parse(strValue5)), strAddr5);
                writeResultRender(busTcpClient.Write(strAddr6, float.Parse(strValue6)), strAddr6);
                writeResultRender(busTcpClient.Write(strAddr7, float.Parse(strValue7)), strAddr7);
            }
            catch (Exception ex)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //0,抓取;1，抓取金手指
            string strAddr1 = "7";
            string strValue1 = "11";
            string strAddr2 = "5";
            string strValue2 = "1111";
            try
            {
                writeResultRender(busTcpClient.Write(strAddr1, float.Parse(strValue1)), strAddr1);
                writeResultRender(busTcpClient.Write(strAddr2, float.Parse(strValue2)), strAddr2);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// log写入listbox控件
        /// </summary>
        /// <param name="s"></param>
        public void writeListBox(string s)
        {
            string stringLog = System.DateTime.Now.ToString() + "-->:" + s;
            this.Invoke((MethodInvoker)delegate
            {
                if (LoglistBox.Items.Count >= 50)
                    LoglistBox.Items.Clear();
                LoglistBox.Items.Add(stringLog);
            });

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //读取更新右托盘
            string strAddr1 = "0";
            string strAddr2 = "14";
            readResultRender(busTcpClient.ReadFloat(strAddr1), strAddr1);
            readResultRender(busTcpClient.ReadFloat(strAddr2), strAddr2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
             // 读取float变量 
            string strAddr1 = "0";
            string strAddr2 = "2";
            string strAddr3 = "4";
            string strAddr4 = "6";
            string strAddr5 = "8";
            string strAddr6 = "10";
            string strAddr7 = "12";
            readResultRender( busTcpClient.ReadFloat(strAddr1), strAddr1);
            readResultRender(busTcpClient.ReadFloat(strAddr2), strAddr2);
            readResultRender(busTcpClient.ReadFloat(strAddr3), strAddr3);
            readResultRender(busTcpClient.ReadFloat(strAddr4), strAddr4);
            readResultRender(busTcpClient.ReadFloat(strAddr5), strAddr5);
            readResultRender(busTcpClient.ReadFloat(strAddr6), strAddr6);
            readResultRender(busTcpClient.ReadFloat(strAddr7), strAddr7);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //读取更新右托盘
            string strAddr1 = "0";
            string strAddr2 = "2";
            string strAddr3 = "4";
            string strAddr4 = "6";
            string strAddr5 = "8";
            string strAddr6 = "10";
            string strAddr7 = "12";
            readResultRender(busTcpClient.ReadFloat(strAddr1), strAddr1);
            readResultRender(busTcpClient.ReadFloat(strAddr2), strAddr2);
            readResultRender(busTcpClient.ReadFloat(strAddr3), strAddr3);
            readResultRender(busTcpClient.ReadFloat(strAddr4), strAddr4);
            readResultRender(busTcpClient.ReadFloat(strAddr5), strAddr5);
            readResultRender(busTcpClient.ReadFloat(strAddr6), strAddr6);
            readResultRender(busTcpClient.ReadFloat(strAddr7), strAddr7);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //busTcpClient.Write("20", float.Parse("1"));
            //string strAddr3 = "20";
            //writeResultRender(busTcpClient.Write(strAddr3, float.Parse(strAddr3)),strAddr3);
            //if (busTcpClient.ReadFloat(strAddr3).IsSuccess)
            //{
            //    toolStripStatusLabel1.Text = "连接成功！";
            //}
            //else
            //{
            //    toolStripStatusLabel1.Text = "连接失败！";
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            busTcpClient.ConnectClose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //抓取次数
            string strAddr1 = "7";
            float ftimes = 1;
            writeResultRender(busTcpClient.Write(strAddr1, ftimes), strAddr1);
            ftimes++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //放料完成
            string strAddr1 = "11";
            float ftimes = 11;
            writeResultRender(busTcpClient.Write(strAddr1, ftimes), strAddr1);
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //开始放料
            string strAddr1 = "9";
            float ftimes = 11;
            writeResultRender(busTcpClient.Write(strAddr1, ftimes), strAddr1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                //开始抓
                button3_Click(null,null);
                //清零寄存器
                string strAddr1 = "7";
                string strValue1 = "0";
                writeResultRender(busTcpClient.Write(strAddr1, float.Parse(strValue1)), strAddr1);
                //等待放
                button11_Click(null, null);
                 strAddr1 = "9";
                 strValue1 = "0";
                writeResultRender(busTcpClient.Write(strAddr1, float.Parse(strValue1)), strAddr1);
                //放完
                button9_Click(null, null);
                strAddr1 = "9";
                strValue1 = "0";
                writeResultRender(busTcpClient.Write(strAddr1, float.Parse(strValue1)), strAddr1);
            }
        }
    }
}
