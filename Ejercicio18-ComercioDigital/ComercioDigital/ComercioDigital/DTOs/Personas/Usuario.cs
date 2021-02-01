﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercioDigital.DTOs.Productos;

namespace ComercioDigital.DTOs.Personas
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Domicilio { get; set; }
        public Carrito CarritoCompra { get; set; }
        public List<Producto> Pedido { get; set; }
        
        public static int Increment { get; set; }
        public int IdUsuario { get; }

        public float Saldo { get; set; }


        public Usuario(string nombre, string domicilio,string password )
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Domicilio = domicilio?? throw new ArgumentNullException(nameof(domicilio));
            CarritoCompra = new Carrito();
            Pedido = new List<Producto>();
            Increment++;
            IdUsuario = Increment;
            Saldo = 10.0f;
        }
    }
}
