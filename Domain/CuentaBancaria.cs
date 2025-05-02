namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public  string Numero { get; protected set; }
    public  decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; } 
    public  decimal TasaDeInteres { get; set; }
    public  decimal LimiteDeDescubierto { get; set; }
    public  decimal Comision { get; set; }
    public  string[] Titulares { get; protected set;  }

    public CuentaBancaria(string numero, decimal saldo,  string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    public void VerificarMontoEstado(decimal monto)
    {
        if(monto < 0) throw new MontoNoValido("El monto tiene que ser mayor a 0");
        if (Estado != Estado.Activa) throw new CuentaNoActiva(Estado);
    }
    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void AplicarInteres();


}
