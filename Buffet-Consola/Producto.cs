namespace Buffet_Consola
{
    public class Producto
    {
        private string nombre;
        private int precio;
        private int cantidad;

        public Producto(string nombre, int precio, int cantidad)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Cantidad { get => cantidad; set => cantidad = value; }
    }

}
