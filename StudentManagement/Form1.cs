using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        private StudentManagerServices services;
        private StudentDAOContainer db;
        public static int request = 0;
        public static int index =0;
        private List<Students> students;
        
        public Form1()
        {
            InitializeComponent();
            services = new StudentManagerServices();
            db = new StudentDAOContainer();
            RefreshData();
        }
        private void RefreshData()
        {
            students = services.showAllData();
        }
        private void PrintIn4Student()
        {
            Students st = students.ElementAt(index);
            txt_id.Text = st.mssv+"";
            txt_name.Text = st.name;
            txt_date.Text = st.birthday + "";
            txt_address.Text = st.address;
            txt_phone.Text = st.phone;
            txt_email.Text = st.email;
            if (st.sex == 1)
                rbtn_nam.Checked = true;
            else
                rbtn_nu.Checked = true; 
        }
        private void ResetStatus()
        {
            //set editabe 
            txt_id.ReadOnly = true;
            txt_name.ReadOnly = true;
            txt_date.ReadOnly = true;
            txt_address.ReadOnly = true;
            txt_phone.ReadOnly = true;
            txt_email.ReadOnly = true;
            //Enable btn
            btn_add.Enabled = true;
            rbtn_nam.Enabled = false;
            btn_edit.Enabled = true;
            rbtn_nu.Enabled = false;
            btn_del.Enabled = true;
            btn_next.Enabled = true;
            btn_pre.Enabled = true;
            //Disable btn save and cancel
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            //print info student from db
            PrintIn4Student();

           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PrintIn4Student();
        }
   
        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            request = 1;
            //set editabe 
            txt_id.ReadOnly = true;
            txt_name.ReadOnly = false;
            txt_date.ReadOnly = false;
            txt_address.ReadOnly = false;
            txt_phone.ReadOnly = false;
            txt_email.ReadOnly = false;
            //disable btn
            btn_add.Enabled = false;
            rbtn_nam.Enabled = true;
            btn_edit.Enabled = false;
            rbtn_nu.Enabled = true;
            btn_del.Enabled = false;
            btn_next.Enabled = false;
            btn_pre.Enabled = false;
            //Enable btn save and cancel
            btn_save.Enabled = true;
            btn_cancel.Enabled = true;
            //Set Text mssv
            txt_id.Text = "AUTO";
            //Clear text

            txt_name.Text = "";
            txt_date.Text = "";
            txt_address.Text = "";
            txt_phone.Text = "";
            txt_email.Text = "";
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            request = 2;
            //disable btn
            btn_add.Enabled = false;
            rbtn_nam.Enabled = false;
            btn_edit.Enabled = false;
            rbtn_nu.Enabled = false;
            btn_del.Enabled = false;
            btn_next.Enabled = false;
            btn_pre.Enabled = false;
            //Enable btn save and cancel
            btn_save.Enabled = true;
            btn_cancel.Enabled = true;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            request = 3;
            //set editabe 
            txt_id.ReadOnly = true;
            txt_name.ReadOnly = false;
            txt_date.ReadOnly = false;
            txt_address.ReadOnly = false;
            txt_phone.ReadOnly = false;
            txt_email.ReadOnly = false;
            //disable btn
            btn_add.Enabled = false;
            rbtn_nam.Enabled = true;
            btn_edit.Enabled = false;
            rbtn_nu.Enabled = true;
            btn_del.Enabled = false;
            btn_next.Enabled = false;
            btn_pre.Enabled = false;
            //Enable btn save and cancel
            btn_save.Enabled = true;
            btn_cancel.Enabled = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            switch (request)
            {
                case 1:
                    {
                        string name = txt_name.Text;
                        int birthday = Int32.Parse(txt_date.Text);
                        int sex = 0;
                        if (rbtn_nam.Checked == true)
                            sex = 1;
                        string address = txt_address.Text;
                        string email = txt_email.Text;
                        string phone = txt_phone.Text;
                        if (services.Insert(name, birthday, sex, phone, address, email))
                        {
                            MessageBox.Show("Thêm Vào Thành Công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Thêm vào thất bại", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 3:
                    {
                        int id = Int32.Parse(txt_id.Text);
                        string name = txt_name.Text;
                        int birthday = Int32.Parse(txt_date.Text);
                        int sex = 0;
                        if (rbtn_nam.Checked == true)
                            sex = 1;
                        string address = txt_address.Text;
                        string email = txt_email.Text;
                        string phone = txt_phone.Text;
                        if (services.Edit(id, name, birthday, sex, phone, address, email))
                        {
                            MessageBox.Show("Chỉnh Sửa Thành Công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Chỉnh Sửa  thất bại", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    {
                       
                        int id = Int32.Parse(txt_id.Text);
                        if(MessageBox.Show("Có chắc xóa SV [" + txt_name.Text+ "]", "Xác nhận",
                            MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (services.Delete(id))
                            {
                                MessageBox.Show("Sửa Thành Công", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Sửa thất bại", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }
                    break;
            }
            RefreshData();
            index = students.Count - 1;
            ResetStatus();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ResetStatus();
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                MessageBox.Show("Hết danh sách", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                PrintIn4Student();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            index++;
            if (index > students.Count-1)
            {
                MessageBox.Show("Hết danh sách", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                PrintIn4Student();
        }
    }
}
