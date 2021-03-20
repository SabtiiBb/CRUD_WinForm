using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_WinForm.Data.Services.Services;
using CRUD_WinForm.FormModels;
using DataMode.SQL.Model.Data.SQL;

namespace CRUD_WinForm
{
    public partial class Form1 : Form
    {
        private readonly NetUsersRepository _manejoUsuarios = new NetUsersRepository();

        public Form1()
        {
            InitializeComponent();
        }

        public bool CrearUsuario(UsersCLS model)
        {
            NetUser user = new NetUser();
            user.UserName = model.UserName;
            user.UserPass = model.Pass;

            bool exito = _manejoUsuarios.CrearUsuario(user);
            return exito;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result;
            if(!String.IsNullOrEmpty(txtUser.Text) || !String.IsNullOrEmpty(txtPass.Text) || !String.IsNullOrEmpty(txtConfirmPass.Text))
            {
                if(txtPass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("Las Passwords no coinciden!", "ERROR!");
                }
                else
                {
                    UsersCLS model = new UsersCLS(){
                        UserName = txtUser.Text,
                        Pass = txtPass.Text
                    };
                    result = CrearUsuario(model);
                }
            }
        }
    }
}
