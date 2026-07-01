namespace parcial_backend.Models
{
    public class TablaPosicion
    {
        public int EquipoId { get; set; }
        public string EquipoNombre { get; set; } = string.Empty;
        public int PJ { get; set; }
        public int PG { get; set; }
        public int PE { get; set; }
        public int PP { get; set; }
        public int GF { get; set; }
        public int GC { get; set; }
        public int DG { get; set; }
        public int Puntos { get; set; }
    }
}
