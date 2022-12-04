﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Controlers;
using ventaVideojuegos.Modelo;
using ventaVideojuegos.UsersControls;

namespace ventaVideojuegos
{
    public partial class FormValidarVenta : Form
    {

        public Venta ventaNueva;
        public string empleado;
        public string cliente;
        public int stockk;

        public FormValidarVenta()
        {
            InitializeComponent();
           
            controladorUsuarios.IniciarRepositorio();
            ControladorClientes.IniciarRepositorio();
            ControladorProductos.IniciarRepositorio();
            ControladorVentas.IniciarRepositorio();

            limpiarErrores();
            llenarBox();
            txtPw.Hide();
            lblPw.Hide();

            txtID.Text = (ControladorVentas.lastId + 1).ToString();
            boxClientes.Text = "consumidor final";
        }

        private void limpiarErrores()
        {
            errEmpleado.Text = "";
            errPw.Text = "";

            errEmpleado.Hide();
            errPw.Hide();

        }

        private void llenarBox()
        {
            List<Cliente> listCte = new List<Cliente>();
            listCte = ControladorClientes.Clientes.Where(x => x.Id != 0).ToList();
            llenarBoxClientes(listCte);

            List<Usuario> listUsu = new List<Usuario>();
            listUsu = controladorUsuarios.Usuarios.Where(x => x.Id != 0).ToList();
            llenarBoxEmpleados(listUsu);
        }

        private void llenarBoxClientes(List<Cliente> listaClientes)
        {
            foreach (Cliente cte in listaClientes)
            {
                if (cte.Vista == true)
                {
                    boxClientes.Items.Add(cte.NUsuario);
                }
            }
        }

        private void llenarBoxEmpleados(List<Usuario> listaUsuarios)
        {
            foreach (Usuario usu in listaUsuarios)
            {
                if (usu.EsAdmin == false)
                {
                    boxEmpleados.Items.Add(usu.Nombre);
                }
            }
        }

        private void liberarContraseña()
        {
            txtPw.Show();
            lblPw.Show();
        }


        private void boxEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            liberarContraseña();
        }

        private void btnFinalCompra_Click(object sender, EventArgs e)
        {
            bool ventaValidada = ValidarVenta(out bool errorMsg);

            if (ventaValidada)
            {
                cliente = boxClientes.Text;
                empleado = boxEmpleados.Text;
                stockk = int.Parse(txtID.Text);

                // descontarStock(cantStock);
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarVenta(out bool errorMsg)
        {
            errorMsg = true;

            if (string.IsNullOrEmpty(boxEmpleados.Text))
            {
                string error = "Debe seleccionar el vendedor";
                errEmpleado.Text = error;
                errEmpleado.Show();
                errorMsg = false;
            }
            else
            {
                errEmpleado.Hide();

                foreach (Usuario usr in controladorUsuarios.Usuarios)
                {


                    if (usr.Nombre.Equals(boxEmpleados.SelectedItem.ToString()) && usr.Contrasena != txtPw.Text)
                    {
                        string error = "Contraseña incorrecta";
                        errPw.Text = error;
                        errPw.Show();
                        errorMsg = false;

                    }
                    else
                    {
                        errPw.Hide();
                    }

                }

                
            }
            return errorMsg;
        }

    }
}