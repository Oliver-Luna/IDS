namespace MVCCRUD.Models
{
    public class Estudiante
    {
       public Estudiante() { }

        public int Id { get; set; }
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int PrimerParcial { get; set; }
        public int SegundoParcial { get; set; }
        public int Sistematico { get; set; }
        public int NotaFinal { get; set; }
    }
}
