﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NUsuario { get; set; }
        public string Email { get; set; }
       // public string Contrasena { get; set; }

        public bool Vista = true;

    }
}
