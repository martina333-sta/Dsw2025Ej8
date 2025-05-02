namespace Dsw2025Ej8.Domain
{
    public class MontoNoValido : Exception
    {
        public MontoNoValido(string mensaje = 
            "El monto ingresado no es valido para la operacion solicitada"): base(mensaje) { }
    }

    public class CuentaNoActiva : Exception
    {
        public CuentaNoActiva(Estado estado):base($"No se puede operar la cuenta{estado}") { }
    }

    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente(string mensaje = 
            "La cuenta no cuenta con saldo para la operacion solicitada. Fue suspendida"): base(mensaje) { }
    }
}
