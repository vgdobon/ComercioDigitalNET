using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercioDigital.DTOs.Personas;
using ComercioDigital.DTOs.Productos;
using ComercioDigital.DTOs.Productos.Moda;
using ComercioDigital.DTOs.Productos.Multimedia;
using ComercioDigital.DTOs.Productos.Tecnologia;
using ComercioDigital.Servicio;

namespace ComercioDigital.Presentacion
{
    public class MenuUsuario
    {

        public void EjecutarMenuUsuario(Usuario usuarioSesion ,GestionComercio gestionComercio, GestionUsuarios gestionUsuarios)
        {

            int opcionTemp =-1;
            while (opcionTemp < 6)
            { 
                MostrarMenuUsuarios();
                opcionTemp = ElegirOpcionUsuario();
                EjecutarOpcionUsuario(opcionTemp, gestionComercio, gestionUsuarios,usuarioSesion);
            }
           
            
        }

        public void EjecutarOpcionUsuario(int opcion, GestionComercio gestionComercio, GestionUsuarios gestionUsuarios,Usuario usuarioSesion)
        {

            switch (opcion)
            {
                case 1:

                    Console.WriteLine("TECNOLOGIA");
                    Console.WriteLine("1-Filtrar Ordenadores");
                    Console.WriteLine("2-Filtrar Moviles");
                    Console.WriteLine("3-Filtrar Videoconsolas");

                    bool opcionTecnologiaIsInt = int.TryParse(Console.ReadLine(), out int opcionTecnologia);
                    if (opcionTecnologiaIsInt)
                    {
                        switch (opcionTecnologia)
                        {
                            case 1:
                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Ordenador)
                                    {
                                        Console.WriteLine(producto);
                                    }
                                }

                                break;

                            case 2:
                                Console.Write("Minimas pulgadas de pantalla:");
                                float.TryParse(Console.ReadLine(), out float pantalla);

                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Movil)
                                    {
                                        Movil movilFilto =(Movil) producto;

                                        if (movilFilto.Pantalla > pantalla)
                                        {
                                            Console.WriteLine(movilFilto);
                                        }
                                    }
                                }
                                break;

                            case 3:

                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is VideoConsola)
                                    {
                                        Console.WriteLine(producto);
                                    }
                                }

                                break;
                        }
                    }

                    

                    Console.WriteLine("Escriba el id del producto que quieres añadir a tu carrito.");
                    Console.Write("Id producto:");

                    bool idProductoTecnologiaCarritoIsInt = int.TryParse(Console.ReadLine(), out int idProductoTecnolgiaCarrito);
                    if (idProductoTecnologiaCarritoIsInt && gestionComercio.ExisteProductoId(idProductoTecnolgiaCarrito))
                    {
                        usuarioSesion.CarritoCompra.CarritoCompra.Add(gestionComercio.GetProductoId(idProductoTecnolgiaCarrito));
                        if (gestionComercio.GetProductoId(idProductoTecnolgiaCarrito).Stock > 0)
                        {
                            gestionComercio.GetProductoId(idProductoTecnolgiaCarrito).Stock--;
                            usuarioSesion.CarritoCompra.CarritoCompra.Add(gestionComercio.GetProductoId(idProductoTecnolgiaCarrito));
                        }
                        else
                        {
                            Console.WriteLine("No queda stock");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Id de producto erróneo");
                    }

                    break;

                case 2:

                    Console.WriteLine("MODA");
                    Console.WriteLine("Moda");
                    Console.WriteLine("1-Filtrar Calzado");
                    Console.WriteLine("2-Filtrar Ropa");
                    Console.WriteLine("3-Filtrar Joyeria");
                    Console.WriteLine("3-Filtrar Bolsos");

                    bool opcionModaIsInt = int.TryParse(Console.ReadLine(), out int opcionModa);
                    if (opcionModaIsInt)
                    {
                        switch (opcionModa)
                        {
                            case 1:
                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Calzado)
                                    {
                                        Console.WriteLine(producto);
                                    }
                                }

                                break;

                            case 2:
                                Console.Write("Minimas pulgadas de pantalla:");
                                string tipo = Console.ReadLine();

                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Ropa)
                                    {
                                        Ropa ropaFiltro = (Ropa)producto;

                                        if (ropaFiltro.Tipo.Equals(tipo))
                                        {
                                            Console.WriteLine(ropaFiltro);
                                        }
                                    }
                                }
                                break;

                            case 3:

                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Joyeria)
                                    {
                                        Console.WriteLine(producto);
                                    }
                                }

                                break;

                            case 4:

                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Bolso)
                                    {
                                        Console.WriteLine(producto);
                                    }
                                }

                                break;
                        }
                    }
                  

                    Console.WriteLine("Escriba el id del producto que quieres añadir a tu carrito.");
                    Console.Write("Id producto:");
                    bool idProductoModaCarritoIsInt = int.TryParse(Console.ReadLine(), out int idProductoModaCarrito);
                    if (idProductoModaCarritoIsInt && gestionComercio.ExisteProductoId(idProductoModaCarrito))
                    {
                        usuarioSesion.CarritoCompra.CarritoCompra.Add(gestionComercio.GetProductoId(idProductoModaCarrito));
                        if (gestionComercio.GetProductoId(idProductoModaCarrito).Stock > 0)
                        {
                            gestionComercio.GetProductoId(idProductoModaCarrito).Stock--;
                            usuarioSesion.CarritoCompra.CarritoCompra.Add(gestionComercio.GetProductoId(idProductoModaCarrito));
                        }
                        else
                        {
                            Console.WriteLine("No queda stock");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Id de producto erróneo");
                    }
                    break;

                case 3:

                    Console.WriteLine("MULTIMEDIA");
                    Console.WriteLine("1-Musica");
                    Console.WriteLine("2-Peliculas o Series");
                    Console.WriteLine("3-Videojuegos");


                    bool opcionMultimediaIsInt = int.TryParse(Console.ReadLine(), out int opcionMultimedia);
                    if (opcionMultimediaIsInt)
                    {
                        switch (opcionMultimedia)
                        {
                            case 1:
                                Console.Write("Artista:");
                                string artista = Console.ReadLine();
                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Musica)
                                    {
                                        Musica musicaFiltro = (Musica) producto;
                                        if (musicaFiltro.Artista.Equals(artista))
                                        {
                                            Console.WriteLine(musicaFiltro);
                                        }
                                        
                                    }
                                }

                                break;

                            case 2:
                                Console.Write("Edad recomendada:");
                                int.TryParse(Console.ReadLine(), out int edadRecomendada);

                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is Pelicula)
                                    {
                                        Pelicula peliculaFilto = (Pelicula)producto;

                                        if (peliculaFilto.EdadRecomendad > edadRecomendada)
                                        {
                                            Console.WriteLine(peliculaFilto);
                                        }
                                    }
                                }
                                break;

                            case 3:
                                Console.Write("Genero:");
                                string genero = Console.ReadLine();

                                Console.Write("Plataforma:");
                                string plataforma= Console.ReadLine();


                                foreach (Producto producto in gestionComercio.Almacen.AlmacenProductos)
                                {
                                    if (producto is VideosJuego)
                                    {
                                        VideosJuego videoJuego = (VideosJuego) producto;
                                        if (videoJuego.Plataforma.Equals(plataforma) &&
                                            videoJuego.Genero.Equals(genero))
                                        {
                                            Console.WriteLine(videoJuego);
                                        }
                                    }
                                }

                                break;
                        }
                    }

                   
                    Console.WriteLine("Escriba el id del producto que quieres añadir a tu carrito.");
                    Console.Write("Id producto:");
                    bool idProductoMultimediaCarritoIsInt = int.TryParse(Console.ReadLine(), out int idProductoMultimediaCarrito);
                    if (idProductoMultimediaCarritoIsInt && gestionComercio.ExisteProductoId(idProductoMultimediaCarrito))
                    {
                        usuarioSesion.CarritoCompra.CarritoCompra.Add(gestionComercio.GetProductoId(idProductoMultimediaCarrito));
                        if (gestionComercio.GetProductoId(idProductoMultimediaCarrito).Stock > 0)
                        {
                            gestionComercio.GetProductoId(idProductoMultimediaCarrito).Stock--;
                            usuarioSesion.CarritoCompra.CarritoCompra.Add(gestionComercio.GetProductoId(idProductoMultimediaCarrito));
                        }
                        else
                        {
                            Console.WriteLine("No queda stock");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Id de producto erróneo");
                    }
                    Console.ReadKey();

                    break;

                case 4:
                    Console.WriteLine("CUENTA");
                    Console.WriteLine("1-Saldo");
                    Console.WriteLine("2-Configuracion");
                    bool opcionCuentaIsInt = int.TryParse(Console.ReadLine(), out int opcionCuenta);
                    if (opcionCuentaIsInt)
                    {
                        switch (opcionCuenta)
                        {
                            case 1:
                                Console.WriteLine("SALDO");
                                Console.WriteLine("1-Consultar saldo");
                                Console.WriteLine("2-Ingresar salgo");
                                bool opcionSaldoIsInt = int.TryParse(Console.ReadLine(), out int opcionSaldo);
                                if (opcionCuentaIsInt)
                                {
                                    switch (opcionSaldo)
                                    {
                                        case 1:
                                            Console.Write($"Saldo de la cuenta: {usuarioSesion.Saldo}");
                                            Console.ReadKey();
                                            break;

                                        case 2:
                                            Console.WriteLine("Ingresar saldo");
                                            Console.Write("Ingrese la cantidad a ingresar:");
                                            bool saldoIsFloat = float.TryParse(Console.ReadLine(), out float saldo);
                                            if (saldoIsFloat)
                                            {
                                                usuarioSesion.Saldo += saldo;
                                            }
                                            Console.ReadKey();

                                            break;
                                    }
                                }

                                break;

                            case 2:
                                Console.WriteLine("Configuracion cuenta de usuario");
                                Console.WriteLine("1-Nombre");
                                Console.WriteLine("2-Contraseña");
                                Console.Write("Elija una opcion:");
                                bool opcionDatosUSuarioIsInt = int.TryParse(Console.ReadLine(), out int opcionDatosUsuario);
                                if (opcionDatosUSuarioIsInt && opcionDatosUsuario > 0 && opcionDatosUsuario < 3)
                                {
                                    switch (opcionDatosUsuario)
                                    {
                                        case 1:
                                            Console.Write("Escriba el nuevo nombre:");
                                            string nuevoNombre = Console.ReadLine();
                                            gestionUsuarios.ModificarUsuario(usuarioSesion, nuevoNombre, "nombre");

                                            break;

                                        case 2:
                                            Console.Write("Escriba la nueva contraseña:");
                                            string nuevaPass = Console.ReadLine();
                                            gestionUsuarios.ModificarUsuario(usuarioSesion, nuevaPass, "contraseña");

                                            break;
                                    }
                                }

                                Console.ReadKey();


                                break;

                            
                        }
                    }

                    break;

                case 5:
                    Console.WriteLine("CARRITO");

                    if (usuarioSesion.CarritoCompra.CarritoCompra.Count > 0)
                    {
                        foreach (Producto productoCarrito in usuarioSesion.CarritoCompra.CarritoCompra)
                        {
                            Console.WriteLine(productoCarrito);
                        }

                        Console.WriteLine("1-Hacer pedido del carrito de compra");
                        Console.WriteLine("2-Eliminar producto");
                        Console.WriteLine("3-Eliminar carrito");

                        bool opcionCarritoIsInt = int.TryParse(Console.ReadLine(), out int opcionCarrito);
                        if (opcionCarritoIsInt)
                        {
                            switch (opcionCarrito)
                            {
                                case 1:
                                    Console.WriteLine("Hacer pedido");
                                    float sumaProductos=0;
                                    foreach (Producto producto in usuarioSesion.CarritoCompra.CarritoCompra)
                                    {
                                        sumaProductos += producto.Precio;
                                        //
                                    }

                                    if (sumaProductos <= usuarioSesion.Saldo)
                                    {
                                        foreach (Producto producto in usuarioSesion.CarritoCompra.CarritoCompra)
                                        {
                                            gestionComercio.GetProductoId(producto.IdProducto).Stock--;
                                        }
                                        usuarioSesion.Saldo -= sumaProductos;
                                        Console.WriteLine($"Pedido realizado.");
                                        usuarioSesion.CarritoCompra.CarritoCompra.Clear();

                                    }
                                    else
                                    {
                                        Console.WriteLine("No tienes suficiente saldo.");
                                    }

                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Eliminar producto del carrito");
                                    foreach (Producto producto in usuarioSesion.CarritoCompra.CarritoCompra)
                                    {
                                        Console.WriteLine(producto);
                                    }

                                    Console.WriteLine("Introduzca el id del producto que quiere eliminar de su carrito");
                                    bool idProductoEliminarIsInt = int.TryParse(Console.ReadLine(),out int idProductoEliminar);

                                    foreach (Producto producto in usuarioSesion.CarritoCompra.CarritoCompra)
                                    {
                                        if (producto.IdProducto == idProductoEliminar)
                                        {
                                            usuarioSesion.CarritoCompra.CarritoCompra.Remove(producto);
                                        }
                                    }

                                    Console.ReadKey();

                                    break;
                                case 3:
                                    Console.WriteLine("Eliminando el carrito completo");
                                    usuarioSesion.CarritoCompra.CarritoCompra.Clear();

                                    Console.WriteLine("Carrito limpio");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No tienes ningun producto en el carrito");
                    }

                    Console.ReadKey();

                    break;

                case 6:

                    Console.WriteLine("Eliminar usuario");
                    Console.Write("Escriba su nombre de usuario si está de acuerdo en eliminar su cuenta: ");
                    string confirmacionEliminacion = Console.ReadLine();

                    if (usuarioSesion.Nombre.Equals(confirmacionEliminacion))
                    {
                        if (gestionUsuarios.EliminarUsuario(usuarioSesion))
                        {
                            Console.WriteLine("Usuario Eliminado correctamente");
                            Console.ReadKey();
                           
                        }
                        else
                        {
                            Console.WriteLine("Error en la eliminacion del usuario");
                        }
                        ;
                    }
                    else
                    {
                        Console.WriteLine("No he escrito correctamente su nombre. Su cuenta no se ha elimnado");
                    }

                    Console.ReadKey();

                    break;

                case 7:
                    Console.WriteLine("Se cerró la sesion de usuario.");
                    Console.ReadKey();
                    break;
            }
        }
        public int ElegirOpcionUsuario()
        {
            bool opcionCorrecta = false;
            int opcionUsuario = -1;
            do
            {
                bool opcionUsuarioIsINt = int.TryParse(Console.ReadLine(), out opcionUsuario);

                if (opcionUsuarioIsINt && opcionUsuario <= 7 && opcionUsuario >= 1)
                {
                    opcionCorrecta = true;
                }
                else
                {
                    Console.WriteLine("No has elegido una opción correcta");
                }
            } while (!opcionCorrecta);

            return opcionUsuario;

        }

        private void MostrarMenuUsuarios()
        {
            Console.Clear();
            Console.WriteLine("1-Tecnologia");
            Console.WriteLine("2-Moda");
            Console.WriteLine("3-Multimedia");
            Console.WriteLine("4-Cuenta");
            Console.WriteLine("5-CarritoCompra");
            Console.WriteLine("6-Eliminar cuenta");
            Console.WriteLine("7-Salir");
            Console.Write("Opcion Menu Principal:");
        }

    }
}
